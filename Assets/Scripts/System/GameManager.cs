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
    private Text textLog;
    private Image logPanel;
    bool isOnAuto = false;
    bool isOnSkip = false;
    bool isPause = false;
    public List<string> logList = new List<string>();


    private static Dictionary<string, Type> CommandTable = new Dictionary<string, Type>
    {
            {"message",typeof(MessageCommand)},
            {"show_character",typeof(ShowCharacterCommand)},
            {"show_background",typeof(ShowBackgroundCommand)},
            {"play_bgm",typeof(PlayBGMCommand)},
            {"play_sfx",typeof(PlaySFXCommand)},
            {"click_wait",typeof(WaitCommand)},
            { "stop_sfx",typeof(StopSFXCommand)},
            { "clear_message",typeof(ClearMessageCommand)},
            { "camera_shake",typeof(ShakeCommand)},
            {"change_scene" ,typeof(ChangeSceneCommand)}
    };

    // Start is called before the first frame update
    void Start()
    {
        //0 false | 1 true
        PlayerPrefs.SetInt("Auto", 0);
        //set to default 
        PlayerPrefs.SetInt("MiniGame", 1);
        logPanel = this.transform.Find("Panel").GetComponent<Image>();
        textLog = this.transform.Find("Panel/TextContainer/LogText").GetComponent<Text>();
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
        if (!m_currentCommand.GetEndGame)
        {
            m_currentCommand.Run();
        }
        else
        {
            NextCommand();
        }

        string logShow = "";
        foreach (string str in logList)
        {
            logShow += (str + "\n"+"\n");
        }
        textLog.text = logShow;

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

    public void AutoButton()
    {
        isOnSkip = false;
        if (isOnAuto)
        {
            isOnAuto = false;

        }
        else
        {
            isOnAuto = true;

        }
    }

    public void SkipButton()
    {
        isOnAuto=false;
        if (isOnSkip)
        {
            isOnSkip = false;
            
        }
        else
        {
            isOnAuto = false;
            isOnSkip = true;

        }
    }

    public void PauseButton()
    {
        if (isPause)
        {
            isPause = false;

        }
        else
        {
            isPause = true;

        }
    }

    public void LogButton()
    {
        if (isPause)
        {
            isPause = false;
            logPanel.gameObject.SetActive(false);
            

        }
        else
        {
            isPause = true;
            logPanel.gameObject.SetActive(true);
        }
    }

    public bool GetIsOnSkip
    {
        get { return isOnSkip; }
    }

    public bool GetIsOnAuto
    {
        get { return isOnAuto; }
    }

    public bool GetIsPause
    {
        get { return isPause; }
    }
    
    public void SetIsPause(bool ispause)
    {
        isPause = ispause;
    }

    public void SetLogList(string loglist)
    {
        logList.Add(loglist);
    }

}
