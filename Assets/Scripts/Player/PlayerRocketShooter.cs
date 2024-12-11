using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocketShooter : MonoBehaviour
{
    [SerializeField] private GameObject rocket;
    [SerializeField] private float secondsPerShoot;
    public int numberOfRockets = 0;

    public void Start()
    {
        InvokeRepeating(nameof(shootRockets), 0f, secondsPerShoot);
    }
    private void shootRockets()
    {
        for (int i = 0; i < numberOfRockets; i++)
        {

            var rocketInstance = Instantiate(rocket, transform.position, Quaternion.identity);
            rocketInstance.GetComponent<TargetRandomEnemy>().getLocation();

        }
    }
}
