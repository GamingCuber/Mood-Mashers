using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemyHealth : MonoBehaviour
{

    public float health = 2f;
    private float playerDamage;
    [SerializeField] private GameObject leftEnemy;
    [SerializeField] private GameObject rightEnemy;
    [SerializeField] private float distanceFromCompEnemy;
    [SerializeField] private Animator splitAnimator;

    void Start()
    {
        // This line gets the player object, gets the PlayerShoot script, and then accesses the playerDamage public field
        playerDamage = GameObject.FindWithTag("Player").GetComponent<PlayerShoot>().playerDamage;
    }

    public void damageSplit(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            killEnemy();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask objectLayer = collision.gameObject.layer;
        // Checks if the Enemy gets hit by an attack by the player
        if (objectLayer == LayerMask.NameToLayer("Attack"))
        {
            health -= playerDamage;
        }
        else if (objectLayer == LayerMask.NameToLayer("Rocket"))
        {

            var rocketDamage = GameObject.FindWithTag("Rocket").GetComponent<TargetRandomEnemy>().rocketDamage;
            health -= rocketDamage;
            Destroy(collision.gameObject);
        }

        if (health <= 0)
        {
            killEnemy();
        }
    }

    private void killEnemy()
    {
        splitAnimator.SetTrigger("isDead");
        Invoke(nameof(destroy), 0.2f);
    }

    private void destroy()
    {
        Vector3 offsetVector = new Vector2(distanceFromCompEnemy, 0);
        Instantiate(leftEnemy, transform.position - offsetVector, Quaternion.identity);
        Instantiate(rightEnemy, transform.position + offsetVector, Quaternion.identity);
        Destroy(gameObject);
    }
}
