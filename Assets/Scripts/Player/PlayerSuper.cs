using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuper : MonoBehaviour
{
    public float secondsPerSuper = 5f;
    void Start()
    {
        InvokeRepeating(nameof(clearEnemies), 0f, secondsPerSuper);
    }

    private void clearEnemies()
    {
        // Gets all things on screen
        var objectList = FindObjectsOfType<GameObject>();
        var enemiesList = new List<GameObject>();
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
        // Goes through the enemies list and destroys all of them
        for (var i = 0; i < enemiesList.Count; i++)
        {
            Destroy(enemiesList[i]);
        }

    }
}
