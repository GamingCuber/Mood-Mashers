using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject weaponParent;

    void Start()
    {
        Panel.SetActive(false);
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime <= 0)
        {
            OpenPanel();
        }
    }

    void OpenPanel()
    {
        Panel.SetActive(true);
        timerText.text = "00:00";
        weaponParent.SetActive(false);
    }
}
