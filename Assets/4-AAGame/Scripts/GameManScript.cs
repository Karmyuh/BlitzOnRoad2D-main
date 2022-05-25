using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManScript : MonoBehaviour
{
    bool gameHasEnded = false;
    [SerializeField] GameObject _endPanel;
    [SerializeField] RotaterScript _rotator;
    [SerializeField] PinSpawnerScript _spawner;
    [SerializeField] Animator _animator;
    public void EndGame()
    {
        if (gameHasEnded)
        {
            return;
           
        }
        gameHasEnded = true;

        _rotator.enabled = false;
        _spawner.enabled = false;
        
        _endPanel.SetActive(true);

        _animator.SetTrigger("EndGame");
        Debug.Log("End Game");

    }

    public void RestartButtonOnClick()
    {   
        SceneManager.LoadScene(5);
        _rotator.enabled = true;
        _spawner.enabled = true;
        _endPanel.SetActive(false);
    }

    public void MainMenuButtonOnClick()
    {
        SceneManager.LoadScene(1);
    }
   
}
