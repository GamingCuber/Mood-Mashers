using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(pauseGame), 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void startGame()
    {

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
            if (currentObject.layer == LayerMask.NameToLayer("Enemy"))
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

    private void pauseGame()
    {

    }
}
