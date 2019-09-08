using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    class WaitCommand : BaseCommand
    {
        GameManager manager;
        public WaitCommand(
            GameObject root,
            IDictionary command) : base(root, command)
        {
            manager = GameObject.Find("Canvas").GetComponent<GameManager>();
        }
		
        public override void Run()
        {
            if (Input.GetMouseButtonDown(0)||
                Input.GetKeyUp(KeyCode.LeftControl)||
                Input.GetKeyUp(KeyCode.RightControl)|| 
				manager.GetIsOnAuto || manager.GetIsOnSkip)
            {
                this.isEndGame = true;
            }

        }
        
    }
}
