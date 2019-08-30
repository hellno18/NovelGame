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
            if (Input.GetMouseButtonDown(0)||
                Input.GetKeyUp(KeyCode.LeftControl)||
                Input.GetKeyUp(KeyCode.RightControl))
            {
                this.isEndGame = true;
            }
        }
    }
}
