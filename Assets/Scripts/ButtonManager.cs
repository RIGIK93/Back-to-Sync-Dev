using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelection;

    public void SwitchMenus()
    {
        if (mainMenu.activeSelf)
        {
            mainMenu.SetActive(false);
            levelSelection.SetActive(true);
        } else
        {
            mainMenu.SetActive(true);
            levelSelection.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
