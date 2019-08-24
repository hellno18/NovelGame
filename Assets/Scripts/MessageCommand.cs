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
        float m_timer = 0.1f;
        private Text _messageText;
        private Text _characterName;
        private int index;
        public MessageCommand(GameObject root, IDictionary command) :base(root, command)
        {
           
            _messageText = root.transform.Find("TextOut/Message").GetComponent<Text>();
            _characterName = root.transform.Find("TextOut/NamePerson").GetComponent<Text>();
        }
        
        public override void Run()
        {
            if (m_isAnimationPlay)
            {

                if (command["id"] != null)
                {
                    index = Convert.ToInt32(command["id"]);
                }
                if (index == 0)
                {
                    _characterName.text = "Unityちゃん";
                }
                else if (index == 1)
                {
                    _characterName.text = "misaki";
                }
                else if (index == 2)
                {
                    _characterName.text = "yuko";
                }
                else if (index == -1)
                {
                    _characterName.text = "???";
                }

                string currentMessage = (string)this.command["text"];
                _messageText.text = currentMessage.Substring(0, m_messageLength);
                m_timer -= Time.deltaTime;
               
                if (m_timer < 0)
                {
                    m_timer = 0.1f;
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
