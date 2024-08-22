using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosionDamage : MonoBehaviour
{
    [SerializeField] private float secondsOut = 0.5f;
    public float rocketDamage = 2.5f;

    void Start()
    {
        Invoke(nameof(destroy), secondsOut);
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
