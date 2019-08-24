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
        Text characterName;
        Image characterImage;
        public ShowCharacterCommand(
            GameObject root,
            IDictionary command) : base(root, command)
        {
           
        }
        
        public override void Run()
        {
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
            if (command["flip"] != null)
            {
                if (command["flip"].ToString() == "right")
                {
                    characterImage.transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    characterImage.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }
           
           
           
            Sprite sprite = resource.GetCharacter(characterID, index);
            characterImage.sprite = sprite;
            for (float i = 0; i <1; i += Time.deltaTime)
            {
                characterImage.color = new Color(1f, 1f, 1f, i);
            }
            
            characterImage.gameObject.SetActive(index >= 0);
            isEndGame = true;
        }
    }
}
