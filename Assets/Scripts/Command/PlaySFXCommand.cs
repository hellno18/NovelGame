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
            se = GameObject.Find("SFX").GetComponent<AudioSource>();
        }

        public override void Run()
        {
            se.volume = PlayerPrefs.GetFloat("sfx");
            // 1 : default bgm , -1 : stop

            int index = -1;
            ScenarioResource resource = ScenarioResource.GetInstace();
            if (command["id"] != null)
            {
                index = Convert.ToInt32(command["id"]);

            }
            AudioClip audioClip = resource.GetSFX(index);
            if (audioClip != null)
            {
                //se.clip = audioClip;
                se.PlayOneShot(audioClip);
            }
            else
            {
                se.Stop();
            }

            isEndGame = true;



        }

    }
}
