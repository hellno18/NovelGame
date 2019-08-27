using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace Assets
{
    class MessageCommand: BaseCommand
    {
        private bool m_isAnimationPlay = true;
        private int m_messageLength = 0;
        float m_timer = 0.05f;
        private Text m_messageText;
        private Text m_characterName;
        private int index;
        public MessageCommand(GameObject root, IDictionary command) :base(root, command)
        {
           
            m_messageText = root.transform.Find("TextOut/Message").GetComponent<Text>();
            m_characterName = root.transform.Find("TextOut/NamePerson").GetComponent<Text>();
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
                    m_timer = 0.05f;
                    m_messageLength++;
                }

                if ( currentMessage.Length< m_messageLength)
                {
                    m_isAnimationPlay = false;
                }
                
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    this.isEndGame = true;
                }
            }
        }


    }
}
