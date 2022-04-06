using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShardWin : MonoBehaviour
{
    [SerializeField] private int currentLevel = -1;

    private void Start()
    {
        if (currentLevel == -1) Debug.LogError("Current level is not set!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<RIGIK93.Character>())
        {
            if (currentLevel > PlayerPrefs.GetInt("CurrentLevel"))
                PlayerPrefs.SetInt("CurrentLevel", currentLevel + 1);
            SceneManager.LoadScene(0);
        }
    }
}
