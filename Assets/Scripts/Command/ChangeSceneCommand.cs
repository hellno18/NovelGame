using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    class ChangeSceneCommand : BaseCommand
    {
        public ChangeSceneCommand(GameObject root, IDictionary command) : base(root, command)
        {
        }
        public override void Run()
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}