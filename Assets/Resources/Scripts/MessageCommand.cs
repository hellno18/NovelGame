using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    class MessageCommand: BaseCommand
    {
        private bool m_isAnimationPlay = true;
        private int m_messageLength = 0;
        float m_timer = 0.1f;
        private Text _messageText;


        public MessageCommand(GameObject root, IDictionary command) :base(root, command)
        {
            GameObject text = GameObject.Find("Message");
            _messageText = text.transform.GetComponent<Text>();
        }
        
        public override void Run()
        {
            if (m_isAnimationPlay)
            {
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
