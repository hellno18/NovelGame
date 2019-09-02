using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace Assets
{
    class MessageCommand: BaseCommand
    {
        GameManager manager;
        
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
        public MessageCommand(GameObject root, IDictionary command) :base(root, command)
        {
            
            m_messageText = root.transform.Find("TextOut/Message").GetComponent<Text>();
            m_characterName = root.transform.Find("TextOut/NamePerson").GetComponent<Text>();
            m_arrow = root.transform.Find("ArrowClick").GetComponent<Image>();
            manager = GameObject.Find("Canvas").GetComponent<GameManager>();
        }
        
        public override void Run()
        {
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
            if (!manager.GetIsOnAuto)
            {
                if (Input.GetKeyUp(KeyCode.LeftControl) || (Input.GetKeyUp(KeyCode.RightControl)))
                {
                    m_skip = false;

                }
                else if (Input.anyKey)
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
                }

                else
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        this.isEndGame = true;
                        m_arrow.gameObject.SetActive(false);
                    }
                }
            }
            else if(manager.GetIsOnAuto)
            {
                m_timerAuto -= Time.deltaTime;
                if (m_timerAuto < 0)
                {
                    m_timerAuto = 1.5f;
                    this.isEndGame = true;
                }
            }
            if (manager.GetIsOnSkip)
            {
                m_timerSkip -= Time.deltaTime;
                if (m_timerSkip < 0)
                {
                    m_timerSkip = 0.09f;
                    this.isEndGame = true;
                }
            }

        }

        


    }
}
