using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
namespace Assets
{
    class ChangeSceneCommand : BaseCommand
    {
        public ChangeSceneCommand(GameObject root, IDictionary command) : base(root, command)
        {
        }
        public override void Run()
        {
            if (command["id"] != null)
            {
                int index = Convert.ToInt32(command["id"]);
                if (index==1)
                {
                    SceneManager.LoadScene("Scene2");
                }
                else if (index == 2)
                {
                    SceneManager.LoadScene("Scene3");
                }
            }

        }
    }
}