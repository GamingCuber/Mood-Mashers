using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] private float healthScaleUp = 1.5f;
    [SerializeField] private float attackScaleUp = 1.5f;
    [SerializeField] private float speedScaleUp = 1.5f;
    [SerializeField] private float hasteScaleUp = 0.75f;
    [SerializeField] private float hammerScaleUp = 1.15f;

    public PlayerHealth playerHealth;
    public PlayerShoot playerShoot;
    public PlayerMovement playerMovement;

    public enum LevelUpgrades
    {
        AttackUp, HammerUp, HasteUp, HealthUp, HomingUp, PlushieUp, SpeedUp, SwirlUp


    }
    public void healthUp()
    {
        playerHealth.maxHealth *= healthScaleUp;
    }

    public void attackUp()
    {
        playerShoot.playerDamage *= attackScaleUp;
    }

    public void speedUp()
    {
        playerMovement.movementSpeed *= speedScaleUp;
    }

    public void hasteUp()
    {
        playerShoot.secondsPerShoot *= hasteScaleUp;
    }

    public void hammerUp()
    {
        scaleUp(hammerScaleUp, playerShoot.leftWave);
        scaleUp(hammerScaleUp, playerShoot.rightWave);
    }

    public void swirl()
    {

    }

    private void scaleUp(float scaling, GameObject gameObject)
    {
        gameObject.transform.localScale *= scaling;
    }
}
