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
    private float bgm=0.5f;
    private float sfx=0.5f;
    Image background;
    Button start;
    Button credit;
    Button option;
    ScenarioResource resource;
    Image panel;
    Image panelOption;
    AudioSource audioSourceBGM;
    AudioSource audioSourceSFX;
    AudioClip audioClip;
    Slider sliderBGM;
    Slider sliderSFX;
    Dropdown dropDown;
    private void Awake()
    {
        _indexBGM = 12;
        PlayerPrefs.SetInt("MiniGame", 0);
        start = this.transform.Find("StartButton").GetComponent<Button>();
        credit = this.transform.Find("CreditButton").GetComponent<Button>();
        option = this.transform.Find("OptionButton").GetComponent<Button>();
        background = this.transform.Find("BG").GetComponent<Image>();
        panel = this.transform.Find("Panel").GetComponent<Image>();
        panelOption= this.transform.Find("PanelOption").GetComponent<Image>();
        sliderBGM = this.transform.Find("PanelOption/SliderBGM").GetComponent<Slider>();
        sliderSFX = this.transform.Find("PanelOption/SliderSFX").GetComponent<Slider>();
        dropDown = this.transform.Find("PanelOption/Dropdown").GetComponent<Dropdown>();

        if (!PlayerPrefs.HasKey("bgm")|| !PlayerPrefs.HasKey("sfx"))
        {
            sliderBGM.value = 0.5f;
            sliderSFX.value = 0.5f;
        }
        else
        {
            bgm = PlayerPrefs.GetFloat("bgm");
            sfx = PlayerPrefs.GetFloat("sfx");
            sliderBGM.value = bgm;
            sliderSFX.value = sfx;
        }
       
        audioSourceBGM = this.GetComponent<AudioSource>();
        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();

        resource = ScenarioResource.GetInstace();
        resource.Load();
        PlayBGM();
    }
    private void FixedUpdate()
    {
        //Update float BGM
        audioSourceBGM.volume = PlayerPrefs.GetFloat("bgm");
        //Update float SFX
        audioSourceSFX.volume = PlayerPrefs.GetFloat("sfx");
    }

    public void DropDown(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                PlaySFX();
                Screen.SetResolution(1280,720,true);
                break;
            case 1:
                PlaySFX();
                Screen.SetResolution(1280, 720, false);
                break;
            default:
                break;
        }
    }

    public void VolumeBGMController()
    {
        PlayerPrefs.SetFloat("bgm", sliderBGM.value);
    }
    public void VolumeSFXController()
    {
        PlayerPrefs.SetFloat("sfx", sliderSFX.value);
    }

    public void StartMenu()
    {
        PlaySFX();
        SceneManager.LoadScene("LoadingScreen");
    }
    public void CreditMenu()
    {
        PlaySFX();
        _indexBGM = 9;
        _indexBG = 20;
        PlayBGM();
        ChangeBackground();
        start.gameObject.SetActive(false);
        credit.gameObject.SetActive(false);
        option.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);
    }

    public void BackButtonCredit()
    {
        PlaySFX();
        _indexBGM = 12;
        _indexBG = 18;
        ChangeBackground();
        PlayBGM();
        start.gameObject.SetActive(true);
        credit.gameObject.SetActive(true);
        option.gameObject.SetActive(true);
        panel.gameObject.SetActive(false);
    }
    public void OptionButton()
    {
        PlaySFX();
        _indexBGM =10;
        _indexBG = 22;
        ChangeBackground();
        PlayBGM();
        start.gameObject.SetActive(false);
        credit.gameObject.SetActive(false);
        option.gameObject.SetActive(false);
        panelOption.gameObject.SetActive(true);
    }

    public void BackButtonOption()
    {
        _indexBGM = 12;
        _indexBG = 18;
        ChangeBackground();
        PlayBGM();
        PlaySFX();
        start.gameObject.SetActive(true);
        credit.gameObject.SetActive(true);
        option.gameObject.SetActive(true);
        panelOption.gameObject.SetActive(false);
    }
    private void PlayBGM()
    {
        audioClip = resource.GetBGM(_indexBGM);
        audioSourceBGM.clip = audioClip;
        audioSourceBGM.Play();
    }

    private void PlaySFX()
    {
        audioSourceSFX.PlayOneShot(resource.GetSFX(15));
    }

    private void ChangeBackground()
    {
        Sprite sprite = resource.GetBackground(_indexBG);
        background.sprite = sprite;
    }
}
