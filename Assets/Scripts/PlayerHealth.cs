using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 20f;

    public void damagePlayer(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            killPlayer();
        }
    }

    void killPlayer()
    {
        Debug.Log("Killed Player");
        gameObject.SetActive(false);
    }
}
