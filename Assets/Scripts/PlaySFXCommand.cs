using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class PlaySFXCommand: BaseCommand
    {
        AudioSource se;
        public PlaySFXCommand(
            GameObject root,
            IDictionary command) : base(root, command)
        {
            se = root.GetComponent<AudioSource>();
        }

        public override void Run()
        {
            // 1 : default bgm , -1 : stop

            int index = -1;
            ScenarioResource resource = ScenarioResource.GetInstace();
            if (command["id"] != null)
            {
                index = Convert.ToInt32(command["id"]);

            }

            if (index == null)
            {
                AudioClip audioClip = resource.GetBGM(1);
                se.clip = audioClip;
                se.Play();
            }
            else
            {
                AudioClip audioClip = resource.GetBGM(index);
                se.clip = audioClip;
                se.Play();
            }

            isEndGame = true;



        }

    }
}
