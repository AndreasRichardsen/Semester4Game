using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuGUI : MonoBehaviour {

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject OptionsMenuUI;


	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
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
        pauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadOptions()
    {
        OptionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
