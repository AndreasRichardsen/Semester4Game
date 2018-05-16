using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject inputsMenuUI;
    public ThirdPersonCamera thirdPersonCamera;


    void Start()
    {
        if (pauseMenuUI == null) pauseMenuUI = GameObject.Find("CanvasPause/PauseMenu"); 
        if(optionsMenuUI == null) optionsMenuUI = GameObject.Find("CanvasPause/OptionsMenu");
        if(inputsMenuUI == null) inputsMenuUI = GameObject.Find("CanvasPause/InputsMenu");
        if(thirdPersonCamera == null) thirdPersonCamera = GameObject.Find("MainCamera").GetComponent<ThirdPersonCamera>();
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        inputsMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
	}

    public void Resume()
    {
        thirdPersonCamera.enabled = true;
        pauseMenuUI.SetActive(false);
        inputsMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        thirdPersonCamera.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadOptions()
    {
        optionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        inputsMenuUI.SetActive(false);
    }

    public void LoadPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    public void LoadInputs()
    {
        inputsMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
