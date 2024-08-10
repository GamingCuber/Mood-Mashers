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
    public GameObject superBar;
    public GameObject pauseMenu;
    public bool isPaused = false;
    [SerializeField] public GameObject pauseMenuFirst;



    void Start()
    {
        pauseMenu.SetActive(false);
        resumeGame();
    }

    // Update is called once per frame
    void Update()
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
        superBar.SetActive(false);
        EventSystem.current.SetSelectedGameObject(pauseMenuFirst);
        Time.timeScale = 0f;
        isPaused = true;        
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        healthBar.SetActive(true);
        superBar.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void toMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("MainMenu");
    }

}
