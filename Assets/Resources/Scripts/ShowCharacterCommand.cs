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
                    characterImage = _root.transform.Find("Character1").GetComponent<CharacterImage>();
                    break;
                case "center":
                    characterImage = _root.transform.Find("Character2").GetComponent<CharacterImage>();
                    break;
                case "right":
                    characterImage = _root.transform.Find("Character3").GetComponent<CharacterImage>();
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
