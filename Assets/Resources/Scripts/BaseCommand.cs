using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    class BaseCommand
    {
        protected GameObject _root;
        protected IDictionary command;
        protected bool isEndGame = false;
                
        //contructor
        public BaseCommand(GameObject root,IDictionary command)
        {
            //gameobject contructor
            _root = root;
            this.command = command;
        }

        public virtual void Run()
        {
          
        }

        public bool GetBool
        {
            get { return isEndGame; }
        }
    }
}
