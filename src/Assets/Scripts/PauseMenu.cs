using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject PauseMenuUI;
    public Text TitleText;
    public Text ResumeText;
    public PlayerController Player;

    bool Death;
    bool Win;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        pauseMenuController();
    }

    void pauseMenuController()
    {
        Death = Player.isPlayerDead;
        Win = Player.isPlayerWinner;

        if (Input.GetKeyDown(KeyCode.Escape)) //<--- This is just here so you get stuck into the menu and it doesnt blink out of existence cuz its looping too fast for unity to handle. 
                                                                //You have to press exit after you die or win.
        {
            CheckTitle();

            if (isGamePaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;

        if (Win || Death)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        Death = false;
        Win = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        isGamePaused = false;
        Application.Quit();
    }

    public void CheckTitle()
    {
        if (Death == true)
        {
            TitleText.text = "YOU DIED";
            ResumeText.text = "Play Again";
        }
        else if (Win == true)
        {
            TitleText.text = "WINNER";
            ResumeText.text = "Play Again";
        }
        else
        {
            TitleText.text = "PAUSED";
            ResumeText.text = "Resume";
        }
    }
}
