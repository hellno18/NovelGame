using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets;

public class GameOver : MonoBehaviour
{
    AudioSource audioSourceSFX;
    AudioSource audioSourceBGM;

    ScenarioResource resource;
    // Update is called once per frame
    private void Start()
    {
		//Load Resource
        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();
        audioSourceBGM = this.transform.GetComponent<AudioSource>();
        audioSourceSFX.volume = PlayerPrefs.GetFloat("sfx");
        audioSourceBGM.volume = PlayerPrefs.GetFloat("bgm");
        resource = ScenarioResource.GetInstace();
        resource.Load();
        audioSourceSFX.PlayOneShot(resource.GetSFX(5));
        audioSourceBGM.clip = resource.GetBGM(6);
        audioSourceBGM.Play();
    }
    void Update()
    {
        StartCoroutine(SceneRoutine());
    }

    IEnumerator SceneRoutine()
    {
        yield return new WaitForSeconds(3f);
        if (PlayerPrefs.GetInt("MiniGame") == 1)
        {
            PlayerPrefs.SetInt("MiniGame", 1);
            SceneManager.LoadScene("MiniGame1");
        }
        else if (PlayerPrefs.GetInt("MiniGame") == 3)
        {
            PlayerPrefs.SetInt("MiniGame", 3);
            SceneManager.LoadScene("MiniGame2");
        }
        else if (PlayerPrefs.GetInt("MiniGame") == 5)
        {
            PlayerPrefs.SetInt("MiniGame", 5);
            SceneManager.LoadScene("MiniGame3");
        }
    }
}
