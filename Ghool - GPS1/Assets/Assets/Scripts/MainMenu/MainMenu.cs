using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //TitleScreen
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    //Options
    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen= isFull;
    }

}
