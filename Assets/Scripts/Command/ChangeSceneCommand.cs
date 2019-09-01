﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
namespace Assets
{
    class ChangeSceneCommand : BaseCommand
    {
        float _timer;
        public ChangeSceneCommand(GameObject root, IDictionary command) : base(root, command)
        {
            _timer = 2f;
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
                    PlayerPrefs.SetInt("MiniGame", 1);
                    SceneManager.LoadScene("LoadingScreen");
                }
                else if(index == 3)
                {
                    PlayerPrefs.SetInt("MiniGame", 3);
                    SceneManager.LoadScene("LoadingScreen");
                }
                else if (index == 4)
                {
                    PlayerPrefs.SetInt("MiniGame", 5);
                    SceneManager.LoadScene("LoadingScreen");
                }
                else if (index == 5)
                {
                    _timer -= Time.deltaTime;
                    PlayerPrefs.SetInt("MiniGame", 7);
                    Debug.Log(_timer);
                    if (_timer < 0)
                    {
                        SceneManager.LoadScene("LoadingScreen");
                    }
                   
                 
                   
                }
                
            }


        }
      
    }
}