using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject pauseMenu;
    public GameObject pauseMenuFirst;
    public bool isPaused = false;

    public void Start()
    {
        pauseMenu.SetActive(false);
        resumeGame();
    }

    // Update is called once per frame
    public void Update()
    {
        var gamepad = Gamepad.current;

        if (Input.GetKeyDown(KeyCode.Escape) || (gamepad != null && gamepad.startButton.wasPressedThisFrame))
        {
            if (isPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }


    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        healthBar.SetActive(false);
        EventSystem.current.SetSelectedGameObject(pauseMenuFirst);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        healthBar.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void toMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void toDemoStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("MainScene");
    }

}
