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
        Animator animator;
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
                    animator = root.transform.Find("Character1").GetComponent<Animator>();
                    break;
                case "center":
                    characterImage = root.transform.Find("Character2").GetComponent<Image>();
                    animator = root.transform.Find("Character2").GetComponent<Animator>();
                    break;
                case "right":
                    characterImage = root.transform.Find("Character3").GetComponent<Image>();
                    animator = root.transform.Find("Character3").GetComponent<Animator>();
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

            if(command["fade"]!=null)
            {
                if (characterID == 0)
                {
                    Fade();
                }
                else if (characterID == 1)
                {
                    Fade();
                }
                else if(characterID == 2)
                {
                    Fade();
                }
                
            }
           
           
           
            Sprite sprite = resource.GetCharacter(characterID, index);
            characterImage.sprite = sprite;            
            characterImage.gameObject.SetActive(index >= 0);
            isEndGame = true;
        }

        private void Fade()
        {
            if (command["fade"].ToString() == "fade_out")
            {
                animator.SetBool("isFade", true);
            }
            else if (command["fade"].ToString() == "fade_in")
            {
                animator.SetBool("isFade", false);
            }
        }
    }
}
