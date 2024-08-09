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
    [SerializeField] private int hammerMaxScale = 5;
    [SerializeField] private int hammerCurrentScale = 1;
    [SerializeField] private float healthRecovery = 20f;
    public HealthBarManager playerHealthBar;

    public PlayerHealth playerHealth;
    public PlayerShoot playerShoot;
    public PlayerMovement playerMovement;
    public PlushiePlayerFollow plushie;
    public GameObject plushieBar;
    public PlushieBarManager plushieBarManager;
    public GameObject homingRocket;

    public enum LevelUpgrades
    {
        AttackUp,
        HammerUp,
        HasteUp,
        HealthUp,
        HomingUp,
        PlushieUp,
        SpeedUp,
        RecoveryUp,
        None
    }
    // Storing Complete Level Upgrades
    public List<LevelUpgrades> completeLevelUpgrades = new List<LevelUpgrades>();
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
                homingUp();
                break;
            case LevelUpgrades.PlushieUp:
                plushieUp();
                break;
            case LevelUpgrades.SpeedUp:
                speedUp();
                break;
            case LevelUpgrades.RecoveryUp:
                recoveryUp();
                break;
        }
    }
    private void healthUp()
    {
        playerHealth.maxHealth *= healthScaleUp;
        playerHealthBar.updateBar();
    }

    private void recoveryUp()
    {
        var newHealth = playerHealth.currentHealth + healthRecovery;
        if (newHealth >= playerHealth.maxHealth)
        {
            newHealth = playerHealth.maxHealth;
        }
        playerHealth.currentHealth = newHealth;

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
        hammerCurrentScale++;
        if (hammerCurrentScale >= hammerMaxScale)
        {
            hammerCurrentScale = hammerMaxScale;
            return;
        }
        scaleUp(hammerScaleUp, playerShoot.leftWave);
        scaleUp(hammerScaleUp, playerShoot.rightWave);
    }

    private void plushieUp()
    {
        playerHealth.plushieHealth = 20f;
        plushie.plushieRenderer.enabled = true;
        plushieBar.SetActive(true);
        plushieBarManager.updateBar();
    }

    private void homingUp()
    {
        var rocketInstance = Instantiate(homingRocket, playerMovement.transform.position, Quaternion.identity);
        rocketInstance.GetComponent<TargetRandomEnemy>().getLocation();
    }

    private void scaleUp(float scaling, GameObject gameObject)
    {
        gameObject.transform.localScale *= scaling;
    }
}
