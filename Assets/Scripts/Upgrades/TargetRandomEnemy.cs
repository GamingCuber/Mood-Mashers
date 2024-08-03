using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class TargetRandomEnemy : MonoBehaviour
{
    [SerializeField] private float homingSpeed;
    [SerializeField] private Rigidbody2D rocketBody;
    public float rocketDamage;
    private Vector2 randomlySelectedEnemyLocation;
    void Start()
    {
        // Gets all things on screen
        var objectList = FindObjectsOfType<GameObject>();
        var enemiesList = new List<GameObject>();
        var random = new System.Random();
        // Goes through everything in game, checking to see if they're an enemy
        for (var i = 0; i < objectList.Length; i++)
        {
            var currentObject = objectList[i];
            // Checks if the object is both an Enemy and is visible to the player, so enemies outside of the player won't get removed
            if (currentObject.layer == LayerMask.NameToLayer("Enemy") && currentObject.GetComponent<SpriteRenderer>().isVisible)
            {
                enemiesList.Add(currentObject);
            }
        }
        enemiesList.OrderBy(x => random.Next()).ToList<GameObject>();
        randomlySelectedEnemyLocation = enemiesList[0].transform.position;
    }

    void Update()
    {
        transform.position = UnityEngine.Vector2.MoveTowards(transform.position, randomlySelectedEnemyLocation, homingSpeed * Time.deltaTime);
        transform.LookAt(randomlySelectedEnemyLocation);
    }
}
