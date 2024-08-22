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
    [SerializeField] private float secondsBetweenAttack = 0.25f;

    void Start()
    {
        leftWave.SetActive(false);
        rightWave.SetActive(false);
        StartCoroutine(shootWaves());
        playerDamage /= 3;
    }


    // Basically a function that uses frames to create an attack
    IEnumerator shootWaves()
    {

        while (true)
        {
            yield return new WaitForSeconds(secondsOut);

            playerAnimator.SetBool("isAttacking", true);
            for (int i = 0; i < timesOut; i++)
            {
                leftWave.SetActive(true);
                rightWave.SetActive(true);
                yield return new WaitForSeconds(secondsBetweenAttack);

                leftWave.SetActive(false);
                rightWave.SetActive(false);
                yield return new WaitForSeconds(secondsBetweenAttack);

            }


            yield return new WaitForSeconds(secondsOut);
            playerAnimator.SetBool("isAttacking", false);
            leftWave.SetActive(false);
            rightWave.SetActive(false);
        }
    }
}
