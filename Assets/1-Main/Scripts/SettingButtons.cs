using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingButtons : MonoBehaviour
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
        SceneManager.LoadScene(2);
    }
    public void ContinueButtonOnClick()
    {
        Time.timeScale = 1;
        _settingsPanel.SetActive(false);
    }
    public void ExitButtonOnClick()
    {
        Application.Quit();
    }

    public void MainMenuButtonOnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

}
