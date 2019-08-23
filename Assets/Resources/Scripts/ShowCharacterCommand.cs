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
            Image characterImage;
            switch (command["position"])
            {
                case "left":
                    characterImage = root.transform.Find("Character1").GetComponent<Image>();
                    break;
                case "center":
                    
                    characterImage = root.transform.Find("Character2").GetComponent<Image>();
                    break;
                case "right":
                    characterImage = root.transform.Find("Character3").GetComponent<Image>();
                    break;
                default:
                    return;
            }

            int characterID = Convert.ToInt32(command["chara_id"]);
            int index;
            ScenarioResource resource = ScenarioResource.GetInstace();

            if (command["id"] != null)
            {
                index = Convert.ToInt32(command["id"]);
                
            }
            else
            {
                index = -1;
            }

            Sprite sprite = resource.GetCharacter(characterID, index);
            characterImage.sprite = sprite;
            characterImage.gameObject.SetActive(index >= 0);
            isEndGame = true;
        }
    }
}
