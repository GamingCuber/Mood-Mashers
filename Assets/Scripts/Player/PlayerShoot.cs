using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject leftWave;
    public GameObject rightWave;
    public float playerDamage = 1.0f;
    public float secondsPerShoot = 2.0f;
    public float secondsOut = 20.0f;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private int timesOut = 3;

    void Start()
    {
        leftWave.SetActive(false);
        rightWave.SetActive(false);
        StartCoroutine(shootWaves());

    }


    // Basically a function that uses frames to create an attack
    IEnumerator shootWaves()
    {

        while (true)
        {
            for (int i = 0; i < timesOut; i++)
            {

            }
            yield return new WaitForSeconds(secondsPerShoot);
            playerAnimator.SetBool("isAttacking", true);
            leftWave.SetActive(true);
            rightWave.SetActive(true);


            yield return new WaitForSeconds(secondsOut);
            playerAnimator.SetBool("isAttacking", false);
            leftWave.SetActive(false);
            rightWave.SetActive(false);
        }
    }
}
