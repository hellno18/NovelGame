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
    class ShowBackgroundCommand : BaseCommand
    {
        Image imageBackgound;
        public ShowBackgroundCommand(
            GameObject root,
            IDictionary command) : base(root, command)
        {
            imageBackgound = root.transform.Find("BG").GetComponent<Image>();
        }

        public override void Run()
        {
            int index=-1;
            ScenarioResource resource = ScenarioResource.GetInstace();

            if (command["id"] != null)
            {
                index = Convert.ToInt32(command["id"]);
            }

            Sprite sprite = resource.GetBackground(index);
            imageBackgound.sprite = sprite;
            isEndGame = true;
            
        }



    }
}
