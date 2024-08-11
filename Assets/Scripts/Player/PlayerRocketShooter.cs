using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocketShooter : MonoBehaviour
{
    [SerializeField] private GameObject rocket;
    [SerializeField] private float secondsPerShoot;

    public void startShootingRockets()
    {
        InvokeRepeating(nameof(shootRocket), 0f, secondsPerShoot);
    }

    private void shootRocket()
    {
        var rocketInstance = Instantiate(rocket, transform.position, Quaternion.identity);
        rocketInstance.GetComponent<TargetRandomEnemy>().getLocation();
    }
}
