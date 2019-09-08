using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace Assets
{
    class MessageCommand: BaseCommand
    {
        private GameManager manager;
        private bool m_isAnimationPlay = true;
        private bool m_skip = false;
        private int m_messageLength = 0;
        private float m_timer = 0.05f;
        private float m_timerAuto=1.5f;
        private float m_timerSkip = 0.09f;
        private Text m_messageText;
        private Text m_characterName;
        private int index;
        private Image m_arrow;
        private Image box;
        private Image logPanel;
        private Button skip;
        private Button auto;
        private Button log;
        

        public MessageCommand(GameObject root, IDictionary command) :base(root, command)
        {
            m_messageText = root.transform.Find("TextOut/Message").GetComponent<Text>();
            m_characterName = root.transform.Find("TextOut/NamePerson").GetComponent<Text>();
            m_arrow = root.transform.Find("ArrowClick").GetComponent<Image>();
            box = root.transform.Find("TextOut").GetComponent<Image>();
            skip= root.transform.Find("TextOut/SkipButton").GetComponent<Button>();
            auto = root.transform.Find("TextOut/AutoButton").GetComponent<Button>();
            log = root.transform.Find("TextOut/LogButton").GetComponent<Button>();
            logPanel = root.transform.Find("Panel").GetComponent<Image>();
            manager = GameObject.Find("Canvas").GetComponent<GameManager>();
           
        }

        public override void Run()
        {
			//if animation is true
            if (m_isAnimationPlay)
            {
                string nameChar= "";
                if (command["name"] != null)
                {
                    nameChar = this.command["name"].ToString();
                }
                m_characterName.text = nameChar;
                
                string currentMessage = (string)this.command["text"];
                m_messageText.text = currentMessage.Substring(0, m_messageLength);
                m_timer -= Time.deltaTime;
                
                if (m_timer < 0)
                {
                    if(!m_skip) m_timer = 0.05f;
                    else m_timer = 0.1f;
                    m_messageLength++;
                }

                if ( currentMessage.Length< m_messageLength)
                {
                    m_isAnimationPlay = false;
                    m_arrow.gameObject.SetActive(true);
                }
                
            }
			//while pressed right mouse
            else if (Input.GetMouseButtonDown(1))
            {
                PauseSystem();
            }
			//while paused
            else if (manager.GetIsPause)
            {
                log.interactable = false;
                auto.interactable = false;
                skip.interactable = false;
                this.isEndGame = false;
            }
            else
            {
                log.interactable = true;
                auto.interactable = true;
                skip.interactable = true;
                if (Input.GetMouseButtonUp(0)||Input.GetKeyDown(KeyCode.LeftControl) ||
                    (Input.GetKeyDown(KeyCode.RightControl)) && !manager.GetIsPause)
                {
                    LogSystem();
                    this.isEndGame = true;
                    m_arrow.gameObject.SetActive(false);
                }
            }
            
			
            if (!manager.GetIsOnAuto)
            {
                if (Input.GetKeyUp(KeyCode.LeftControl) || (Input.GetKeyUp(KeyCode.RightControl)))
                {
                    m_skip = false;

                }
                else if (Input.anyKey && !manager.GetIsPause)
                {
                    foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.RightControl)))
                        {
                            this.isEndGame = true;
                            m_arrow.gameObject.SetActive(false);
                            m_skip = true;
                        }
                    }
                    if (this.isEndGame)
                    {
                        LogSystem();
                    }
                }

            }
			
			//while Auto system is on
            else if(manager.GetIsOnAuto)
            {
                m_timerAuto -= Time.deltaTime;
                if (m_timerAuto < 0)
                {
                    m_timerAuto = 1.5f;
                    this.isEndGame = true;
                }
                if (this.isEndGame)
                {
                    LogSystem();
                }
            }

			//while Skip system is on
            if (manager.GetIsOnSkip)
            {
                m_timerSkip -= Time.deltaTime;
                if (m_timerSkip < 0)
                {
                    m_timerSkip = 0.09f;
                    this.isEndGame = true;
                }
                if (this.isEndGame)
                {
                    LogSystem();
                }
            }

			//while ScrollWheel is going up
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                logPanel.gameObject.SetActive(true);
                manager.SetIsPause(true);

            }
			
			//while ScrollWheel is going down
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                logPanel.gameObject.SetActive(false);
                manager.SetIsPause(false);
            }

        }

        private void LogSystem()
        {
            if (m_characterName.text == "ユキ")
            {
                manager.SetLogList("ユキ： " + command["text"].ToString());
            }
            else if (m_characterName.text == "怜奈")
            {
                manager.SetLogList("怜奈： " + command["text"].ToString());
            }
            else if (m_characterName.text == "薫")
            {
                manager.SetLogList("薫： " + command["text"].ToString());
            }
            else
            {
                manager.SetLogList("---" + command["text"].ToString() + "---");
            }
        }

        private void PauseSystem()
        {
            if (!manager.GetIsPause)
            {
                manager.SetIsPause(true);
                box.gameObject.SetActive(false);
                m_arrow.gameObject.SetActive(false);

                this.isEndGame = false;
            }
            else
            {
                manager.SetIsPause(false);
                box.gameObject.SetActive(true);
                m_arrow.gameObject.SetActive(true);

            }
        }



    }
}
