using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    class BaseCommand
    {
        protected GameObject root;
        protected IDictionary command;
        protected bool isEndGame = false;

        //contructor
        public BaseCommand(GameObject root,IDictionary command)
        {
            //gameobject contructor
            this.root = root;
            this.command = command;
            
        }

        public virtual void Run()
        {
            Debug.Log(command["command_type"] + " はまだオーバーライドされていません");
            isEndGame = true;
        }

        public bool GetEndGame
        {
            get { return isEndGame; }
        }
        

    }
}
