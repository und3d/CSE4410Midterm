using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string sceneName;
    public GameObject MainMenu;
    public GameObject SettingsMenu;

    public void StartClicked()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitCLicked()
    {
        Application.Quit();
    }

    public void BackClicked()
    {
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void SettingsClicked()
    {
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
