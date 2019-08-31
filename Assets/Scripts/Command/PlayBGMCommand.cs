using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class PlayBGMCommand : BaseCommand
    {
        AudioSource bgm;
        public PlayBGMCommand(
            GameObject root,
            IDictionary command) : base(root, command)
        {
            bgm = root.GetComponent<AudioSource>();
        }

        public override void Run()
        {
            // 1 : default bgm , -1 : stop
            
            int index=-1;
            ScenarioResource resource = ScenarioResource.GetInstace();
            if (command["id"] != null)
            {
                index = Convert.ToInt32(command["id"]);
               
            }
            AudioClip audioClip = resource.GetBGM(index);
            if (audioClip != null)
            {
                bgm.clip = audioClip;
                bgm.Play();
            }
            else
            {

                bgm.Stop();
            }

            isEndGame = true;
            
        }
    }
}
