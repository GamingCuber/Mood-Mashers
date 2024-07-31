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
    private LevelUpgrades currentUpgrade;

    public enum LevelUpgrades
    {
        AttackUp,
        HammerUp,
        HasteUp,
        HealthUp,
        HomingUp,
        PlushieUp,
        SpeedUp,
        SwirlUp,
        None
    }
    public void chooseLevelUp(LevelUpgrades upgrade)
    {
        switch (upgrade)
        {
            case LevelUpgrades.AttackUp:
                attackUp();
                break;
            case LevelUpgrades.HammerUp:
                hammerUp();
                break;
            case LevelUpgrades.HasteUp:
                hasteUp();
                break;
            case LevelUpgrades.HealthUp:
                healthUp();
                break;
            case LevelUpgrades.HomingUp:
                break;
            case LevelUpgrades.PlushieUp:
                break;
            case LevelUpgrades.SpeedUp:
                speedUp();
                break;
            case LevelUpgrades.SwirlUp:
                swirl();
                break;
        }
    }
    private void healthUp()
    {
        playerHealth.maxHealth *= healthScaleUp;
    }

    private void attackUp()
    {
        playerShoot.playerDamage *= attackScaleUp;
    }

    private void speedUp()
    {
        playerMovement.movementSpeed *= speedScaleUp;
    }

    private void hasteUp()
    {
        playerShoot.secondsPerShoot *= hasteScaleUp;
    }

    private void hammerUp()
    {
        scaleUp(hammerScaleUp, playerShoot.leftWave);
        scaleUp(hammerScaleUp, playerShoot.rightWave);
    }

    private void swirl()
    {

    }

    private void scaleUp(float scaling, GameObject gameObject)
    {
        gameObject.transform.localScale *= scaling;
    }
}
