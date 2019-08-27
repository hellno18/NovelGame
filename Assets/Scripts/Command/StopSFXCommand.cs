using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class StopSFXCommand : BaseCommand
    {
        AudioSource se;
        public StopSFXCommand(
            GameObject root,
            IDictionary command) : base(root, command)
        {
            se = GameObject.Find("SFX").GetComponent<AudioSource>();
        }
        public override void Run()
        {
            se.Stop();
            isEndGame = true;
        }
    }
    
}
