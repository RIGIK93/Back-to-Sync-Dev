using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int level = -1;

    private void Start()
    {
        if (PlayerPrefs.GetInt("CurrentLevel") <= 0) PlayerPrefs.SetInt("CurrentLevel", 1);
    }
    public void ButtonClick()
    {
        /*if (PlayerPrefs.GetInt("CurrentLevel") >= level)*/ SceneManager.LoadScene(level);
    }
}
