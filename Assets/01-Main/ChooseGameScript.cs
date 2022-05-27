using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseGameScript : MonoBehaviour
{
    public void Start2DGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    public void Start2048Game()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
    public void StartAAGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(5);
    }
    public void StartBowGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(4);
    }
}
