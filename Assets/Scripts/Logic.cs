using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{

    public GameObject GameOverScreen;
    public GameObject StartMenu;
    public GameObject PauseMenu;
    public GameObject VictoryScreen;
    public bool IsPaused = false;





    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        

    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void Victory()
    {
        VictoryScreen.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }


    public void OnPause()
    {


        if (IsPaused == true)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }




    public void ExitGame()
    {

        Application.Quit();
    }


}
