using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsBowGame : MonoBehaviour
{
    [SerializeField] GameObject _panel;

    public void ExitButtonOnClick() 
    {
        Application.Quit();
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(4);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsButton()
    {
        Time.timeScale = 0;
        
        _panel.SetActive(true);
    }
}
