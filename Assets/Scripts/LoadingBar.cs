using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets;

public class LoadingBar : MonoBehaviour
{
    // 1 : minigame1 
    private float _currentValue=0f;
    private Image _filledImage;
    private Text _timerText;
    private int _speed=20;
    private int _random;
    ScenarioResource resource;
    Image _background;
    // Start is called before the first frame update
    void Start()
    {
        _filledImage = this.transform.Find("Red").GetComponent<Image>();
        _timerText= this.transform.Find("White/Text").GetComponent<Text>();

        //resource load
        resource = ScenarioResource.GetInstace();
        resource.Load();

        _random = Random.Range(20, 24);
        _background = this.transform.Find("BG").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _background.sprite = resource.GetBackground(_random);

        //Loading system
        if (_currentValue < 100)
        {
            _currentValue += _speed*Time.deltaTime;
            _timerText.text = ((int)_currentValue).ToString();
            
            //Debug.Log(_currentValue / 100);
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
        if (PlayerPrefs.GetInt("MiniGame") == 0) SceneManager.LoadScene("Scene1");
        else if (PlayerPrefs.GetInt("MiniGame") == 1)
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
        else if (PlayerPrefs.GetInt("MiniGame") == 4)
        {
            SceneManager.LoadScene("Scene4");
        }
        else if (PlayerPrefs.GetInt("MiniGame") == 5)
        {
            SceneManager.LoadScene("MiniGame3");
        }
        else if (PlayerPrefs.GetInt("MiniGame") == 6)
        {
            SceneManager.LoadScene("Scene5");
        }
        else if (PlayerPrefs.GetInt("MiniGame") == 7)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
