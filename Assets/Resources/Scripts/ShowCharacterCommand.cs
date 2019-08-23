using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    class ShowCharacterCommand : BaseCommand
    {
        public ShowCharacterCommand(
            GameObject root,
            IDictionary command) : base(root, command)
        {

        }

        public override void Run()
        {
            CharacterImage characterImage;
            switch (command["position"])
            {
                case "left":
                    GameObject char1 = GameObject.Find("Character1");
                    characterImage = char1.transform.GetComponent<CharacterImage>();
                    break;
                case "center":
                    GameObject char2 = GameObject.Find("Character2");
                    characterImage = _root.transform.GetComponent<CharacterImage>();
                    break;
                case "right":
                    GameObject char3 = GameObject.Find("Character3");
                    characterImage = char3.transform.GetComponent<CharacterImage>();
                    break;
                default:
                    return;
            }

            if (command["id"] != null)
            {
                characterImage.spriteIndex = Convert.ToInt32(command["id"]);
                characterImage.gameObject.SetActive(true);
            }
            else
            {
                characterImage.gameObject.SetActive(false);
            }
            isEndGame = true;
        }
    }
}
