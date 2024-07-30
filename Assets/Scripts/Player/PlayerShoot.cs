using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject leftWave;
    public GameObject rightWave;
    public float playerDamage = 1.0f;
    public float secondsPerShoot = 0.0f;
    public float frames = 3.0f;

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
            yield return new WaitForSeconds(secondsPerShoot);

            leftWave.SetActive(true);
            rightWave.SetActive(true);

            for (var i = 0; i < frames; i++)
            {
                yield return new WaitForEndOfFrame();
            }

            leftWave.SetActive(false);
            rightWave.SetActive(false);
        }
    }
}
