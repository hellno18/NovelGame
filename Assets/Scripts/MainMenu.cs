using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets;

public class MainMenu : MonoBehaviour
{
    private int _indexBGM;
    private int _indexBG;
    Image background;
    Button start;
    Button credit;
    ScenarioResource resource;
    Image panel;
    AudioSource audioSource;
    AudioClip audioClip;
    private void Awake()
    {
        _indexBGM = 12;
        PlayerPrefs.SetInt("MiniGame", 0);
        start = this.transform.Find("StartButton").GetComponent<Button>();
        credit = this.transform.Find("CreditButton").GetComponent<Button>();
        background = this.transform.Find("BG").GetComponent<Image>();
        panel = this.transform.Find("Panel").GetComponent<Image>();
        audioSource = this.GetComponent<AudioSource>();
        resource = ScenarioResource.GetInstace();
        resource.Load();
        PlayBGM();
    }
    
    public void StartMenu()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
    public void CreditMenu()
    {
        _indexBGM = 9;
        _indexBG = 20;
        PlayBGM();
        ChangeBackground();
        start.gameObject.SetActive(false);
        credit.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);

    }

    public void BackButton()
    {
        _indexBGM = 12;
        _indexBG = 18;
        ChangeBackground();
        PlayBGM();
        start.gameObject.SetActive(true);
        credit.gameObject.SetActive(true);
        panel.gameObject.SetActive(false);
    }
    private void PlayBGM()
    {
        audioClip = resource.GetBGM(_indexBGM);
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void ChangeBackground()
    {
        Sprite sprite = resource.GetBackground(_indexBG);
        background.sprite = sprite;
    }
}
