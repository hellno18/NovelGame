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
        Image _camera;
        public ShakeCommand(GameObject root, IDictionary command) : base(root, command)
        {
            _camera = root.transform.Find("BG").GetComponent<Image>();
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
                for(int i = 0; i < 10; i++)
                {
                    _camera.transform.localPosition = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)) * 0.3f;
                }

                if (Input.GetMouseButtonDown(0)|| 
                    Input.GetKeyDown(KeyCode.LeftControl)||
                    Input.GetKeyDown(KeyCode.RightControl))
                {
                    isEndGame = true;
                }
            }
            
        }
    }
}
