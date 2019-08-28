using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace Assets
{
    class ClearMessageCommand : BaseCommand
    {
        private Text m_messageText;
        private Text m_characterName;
        public ClearMessageCommand(GameObject root, IDictionary command) : base(root, command)
        {
            m_messageText = root.transform.Find("TextOut/Message").GetComponent<Text>();
            m_characterName = root.transform.Find("TextOut/NamePerson").GetComponent<Text>();
        }
        public override void Run()
        {
            m_characterName.text = "";
            m_messageText.text = "";
            isEndGame = true;
        }
    }
}
