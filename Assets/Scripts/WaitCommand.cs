using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    class WaitCommand : BaseCommand
    {
        public WaitCommand(
            GameObject root,
            IDictionary command) : base(root, command)
        {
        }
        public override void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.isEndGame = true;
            }
        }
    }
}
