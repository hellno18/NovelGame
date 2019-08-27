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
    [SerializeField] int Story;
    private BaseCommand m_currentCommand;
    private TextAsset m_textArea;
    private JsonNode m_json;
    private List<BaseCommand> commandList;
    private int commandIndex;

    private static Dictionary<string, Type> CommandTable = new Dictionary<string, Type>
    {
            {"message",typeof(MessageCommand)},
            {"show_character",typeof(ShowCharacterCommand)},
            {"show_background",typeof(ShowBackgroundCommand)},
            {"play_bgm",typeof(PlayBGMCommand)},
            {"play_sfx",typeof(PlaySFXCommand)},
            {"click_wait",typeof(WaitCommand)},
            { "stop_sfx",typeof(StopSFXCommand)}
    };

    // Start is called before the first frame update
    void Start()
    {
        ScenarioResource resource = ScenarioResource.GetInstace();
        resource.Load();
        m_json = resource.GetJSON(Story);
        commandList = new List<BaseCommand>();
     
        // DICTIONARY
        IList commands = m_json["commands"].Get<IList>();
        
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
        if (!m_currentCommand.GetBool)
        {
            m_currentCommand.Run();
        }
        else
        {
            NextCommand();
        }
    }

    private bool IsCommandFinish() { return commandList.Count <= commandIndex;  }

    private void NextCommand()
    {
        if (!IsCommandFinish())
        {
            m_currentCommand = commandList[commandIndex];
            commandIndex++;
        }
    }


}
