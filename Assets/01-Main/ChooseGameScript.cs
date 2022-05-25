using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseGameScript : MonoBehaviour
{
    public void Start2DGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Start2048Game()
    {
        SceneManager.LoadScene(3);
    }
    public void StartAAGame()
    {
        SceneManager.LoadScene(5);
    }
    public void StartBowGame()
    {
        SceneManager.LoadScene(4);
    }
}
