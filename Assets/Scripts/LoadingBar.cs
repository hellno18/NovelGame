﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingBar : MonoBehaviour
{
    // 1 : minigame1 
    private float _currentValue=0f;
    private Image _filledImage;
    private Text _timerText;
    private int _speed=20;
    // Start is called before the first frame update
    void Start()
    {
        _filledImage = this.transform.Find("Red").GetComponent<Image>();
        _timerText= this.transform.Find("White/Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentValue < 100)
        {
            _currentValue += _speed*Time.deltaTime;
            _timerText.text = ((int)_currentValue).ToString();
            
            Debug.Log(_currentValue / 100);
        }
        else
        {
            StartCoroutine(LoadingAfter());
        }
        _filledImage.fillAmount = _currentValue / 100;

    }
    
    IEnumerator LoadingAfter()
    {
        _timerText.text = "終了";
        yield return new WaitForSeconds(1f);
        if (PlayerPrefs.GetInt("MiniGame") == 1)
        {
            SceneManager.LoadScene("MiniGame1");
        }
        else if (PlayerPrefs.GetInt("MiniGame") == 2)
        {
            SceneManager.LoadScene("Scene3");
        }
        else if (PlayerPrefs.GetInt("MiniGame") == 3)
        {
            SceneManager.LoadScene("MiniGame2");
        }
    }
}