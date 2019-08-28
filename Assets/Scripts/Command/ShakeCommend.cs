using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    class ShakeCommand : BaseCommand
    {
        //TODO CAMERA SHAKE
        private bool _isShake=false;
        GameObject _camera;
        public ShakeCommand(GameObject root, IDictionary command) : base(root, command)
        {
            _camera = GameObject.Find("Main Camera");
        }
        public override void Run()
        {
            if (command["shake"] != null)
            {
                _isShake = true;
               
            }
            else
            {
                _isShake = false;
            }
            if (_isShake)
            {
                _camera.transform.localPosition = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)) * 0.3f;
                isEndGame = true;
            }
            

        }
    }
}
