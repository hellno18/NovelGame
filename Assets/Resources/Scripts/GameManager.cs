using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using MiniJSON;
using Assets;

public class GameManager : MonoBehaviour
{
    public TextAsset scriptTextFile;
    public GameObject message;

    private BaseCommand _currentCommand;

    private TextAsset m_textArea;
    private JsonNode m_json;
    private List<BaseCommand> commandList;
    private int commandIndex;

    private static Dictionary<string, Type> CommandTable = new Dictionary<string, Type>
    {
            {"message",typeof(MessageCommand)},
            {"show_character",typeof(ShowCharacterCommand)},
            {"show_background",typeof(ShowBackgroundCommand)},
            {"play_bgm",typeof(PlayBGMCommand)}
    };

    // Start is called before the first frame update
    void Start()
    {
        commandList = new List<BaseCommand>();

        //showMessage = new ShowMessageAnimation(m_messageBox,);
        // m_textArea = Resources.Load("Scripts/SampleScript") as TextAsset;
        m_json = JsonNode.Parse(scriptTextFile.text);


        // DICTIONARY
        IList commands = m_json["commands"].Get<IList>();
        /*
        foreach (IDictionary command in commands)
        {
            BaseCommand baseCommand;
            switch (command["command_type"].ToString())
            {
                case "message":
                    baseCommand = new MessageCommand(this.gameObject, command);
                    break;
                case "show_character":
                    baseCommand = new ShowCharacterCommand(this.gameObject, command);
                    break;
                case "play_bgm":
                    baseCommand = new PlayBGMCommand(this.gameObject, command);
                    break;
                case "show_background":
                    baseCommand = new ShowBackgroundCommand(this.gameObject, command);
                    break;
                default:
                    baseCommand = new BaseCommand(this.gameObject, command);
                    break;
            }
            commandList.Add(baseCommand);
        }
        */
        foreach (IDictionary command in commands)
        {
            string command_type = command["command_type"].ToString();
            object[] args = new object[] { gameObject, command };

            Type CommandType = CommandTable.ContainsKey(command_type) ? 
                CommandType = CommandTable[command_type]: 
                CommandType = typeof(BaseCommand);

            BaseCommand baseCommand = (BaseCommand)Activator.CreateInstance(CommandType, args);
            commandList.Add(baseCommand);
        }

        commandIndex = 0;
        NextCommand();

    }




    // Update is called once per frame
    void Update()
    {
        if (!_currentCommand.GetBool)
        {
            _currentCommand.Run();
        }
        else NextCommand();
    }

    private bool IsCommandFinish() { return commandList.Count <= commandIndex;  }

    private void NextCommand()
    {
        if (!IsCommandFinish())
        {
            _currentCommand = commandList[commandIndex];
            commandIndex++;
        }
    }


}
