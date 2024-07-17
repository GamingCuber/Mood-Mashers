using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseMenuManager PauseManager;


    private void Awake()
    {
        PauseManager = GetComponent<PauseMenuManager>();
    }

    public void OpenPanel()
    {
        PauseManager.pauseGame();
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        PauseManager.resumeGame();
        panel.SetActive(false);
    }

}
