using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets;

public class MiniGameManager : MonoBehaviour
{
	//minigame state?
    [SerializeField] private int _miniGameStage;
    
	private int _currCount=0;
    private Image _health;
    private AudioSource _audioSourceBGM;
    private AudioSource _audioSourceSFX;
    private bool[] isButton = new bool[3];
    ScenarioResource resource;
    AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
		//Load Resource
        _currCount = 0;
        _health = this.transform.Find("Health").GetComponent<Image>();
        _audioSourceBGM = this.GetComponent<AudioSource>();
        _audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();
        _audioSourceSFX.volume = PlayerPrefs.GetFloat("sfx");
        _audioSourceBGM.volume = PlayerPrefs.GetFloat("bgm");
        resource = ScenarioResource.GetInstace();
        resource.Load();
        audioClip = resource.GetSFX(1);
        _audioSourceBGM.clip= resource.GetBGM(3);
        _audioSourceBGM.Play();
    }

    public void UpButton()
    {
        //play sfx
        _audioSourceSFX.PlayOneShot(audioClip);

        isButton[0] = true;
        Run();
        StartCoroutine(ButtonRoutine());
    }
    public void LeftButton()
    {
        //play sfx
        _audioSourceSFX.PlayOneShot(audioClip);
        isButton[1] = true;
        Run();
        StartCoroutine(ButtonRoutine());
    }
    public void RightButton()
    {
        //play sfx
        _audioSourceSFX.PlayOneShot(audioClip);
        isButton[2] = true;
        Run();
        StartCoroutine(ButtonRoutine());
    }
    private void Run()
    {
		//Gameplay minigame 1-3
        switch (_miniGameStage)
        {
            case 1:
                if (_currCount < 3)
                {
                    if (_currCount == 0)
                    {
                        if (isButton[0])
                        {
                            _currCount += 1;
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                            //Failed Game
                            if (_health.fillAmount<=0) StartCoroutine(FinishRoutine());
                        }
                    }
                    else if (_currCount == 1)
                    {
                        if (isButton[2])
                        {
                            _currCount += 1;
                            
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                        }
                    }
                    else if(_currCount == 2)
                    {
                        if (isButton[0])
                        {
                            StartCoroutine(FinishRoutine());
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                        }
                    }
                    
                }
                break;
            case 2:
                if (_currCount < 4)
                {
                    if (_currCount == 0)
                    {
                        if (isButton[2])
                        {
                            _currCount += 1;
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                            if (_health.fillAmount <= 0) StartCoroutine(FinishRoutine());
                        }
                    }
                    else if (_currCount == 1)
                    {
                        if (isButton[0])
                        {
                            _currCount += 1;
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                        }
                    }
                    else if (_currCount == 2)
                    {
                        if (isButton[2])
                        {
                            _currCount += 1;
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                        }
                    }
                    else if (_currCount == 3)
                    {
                        if (isButton[1])
                        {
                            StartCoroutine(FinishRoutine());
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                        }
                    }
                }
                break;
            case 3:
                if (_currCount < 5)
                {
                    if (_currCount == 0)
                    {
                        if (isButton[0])
                        {
                            _currCount += 1;
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                            if (_health.fillAmount <= 0) StartCoroutine(FinishRoutine());
                        }
                    }
                    else if (_currCount == 1)
                    {
                        if (isButton[2])
                        {
                            _currCount += 1;
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                        }
                    }
                    else if (_currCount == 2)
                    {
                        if (isButton[0])
                        {
                            _currCount += 1;
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                        }
                    }
                    else if (_currCount == 3)
                    {
                        if (isButton[1])
                        {
                            _currCount += 1;
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                        }
                    }
                    else if (_currCount == 4)
                    {
                        if (isButton[2])
                        {
                            StartCoroutine(FinishRoutine());
                        }
                        else
                        {
                            _currCount = 0;
                            _health.fillAmount -= 0.35f;
                        }
                    }
                }
                break;
        }  
    }
    
	//false route
    IEnumerator ButtonRoutine()
    {
        yield return new WaitForSeconds(1f);
        for(int i = 0; i < 3; i++)
        {
            isButton[i] = false;
        }
        _audioSourceSFX.Stop();
    }
    
	//True route or die
	IEnumerator FinishRoutine()
    {
        yield return new WaitForSeconds(1f);
        _audioSourceSFX.Stop();
        if (_health.fillAmount <= 0)
        {
            //Failed
            SceneManager.LoadScene("GameOver");
        }
        else if(_miniGameStage==1)
        {
            PlayerPrefs.SetInt("MiniGame", 2);
            //Clear Game
            SceneManager.LoadScene("LoadingScreen");
        }
        else if (_miniGameStage == 2)
        {
            PlayerPrefs.SetInt("MiniGame", 4);
            //Clear Game
            SceneManager.LoadScene("LoadingScreen");
        }
        else if (_miniGameStage == 3)
        {
            PlayerPrefs.SetInt("MiniGame", 6);
            //Clear Game
            SceneManager.LoadScene("LoadingScreen");
        }
    }

}
