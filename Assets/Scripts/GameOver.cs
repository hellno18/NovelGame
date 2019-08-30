using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    // Update is called once per frame
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
    }
}
