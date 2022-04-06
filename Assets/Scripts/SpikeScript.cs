using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<RIGIK93.Character>())
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
