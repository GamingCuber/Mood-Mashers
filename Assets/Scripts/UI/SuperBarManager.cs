using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuperBarManager : MonoBehaviour
{
    public PlayerSuper playerSuper;
    private float timePassed;
    [SerializeField] private Image superBar;
    [SerializeField] private TMP_Text superBarText;

    void Update()
    {
        timePassed += Time.deltaTime;
        float fillAmount = timePassed / playerSuper.secondsPerSuper;
        superBar.fillAmount = fillAmount;
        if (fillAmount >= 0.99f)
        {
            superBarText.enabled = true;
        }
    }

    public void resetBar()
    {
        timePassed = 0f;
    }
}
