using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main2048 : MonoBehaviour
{
    [SerializeField] GameObject _settingsPanel;

    public void SettingsButtonOnClick()
    {
        Time.timeScale = 0;
        _settingsPanel.SetActive(true);
    }

    public void RestartButtonOnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
    public void ExitButtonOnClick()
    {
        Application.Quit();
    }
    public void MainMenuOnClick() 
    {
        SceneManager.LoadScene(1);
    }

   
}
