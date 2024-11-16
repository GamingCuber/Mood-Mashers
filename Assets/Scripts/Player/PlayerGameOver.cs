using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponParent;
    [SerializeField] GameObject eventSystem;
    [SerializeField] GameObject mainMenuButton;
    public void GameOver()
    {
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(mainMenuButton);
        GetComponent<PlayerMovement>().enabled = false;
        gameOverPanel.SetActive(true);
        weaponParent.SetActive(false);
        Time.timeScale = 0f;
    }
}
