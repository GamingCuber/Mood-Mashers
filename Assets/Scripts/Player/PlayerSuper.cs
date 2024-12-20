using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSuper : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float superDamage;
    [SerializeField] private SuperBarManager superBarManager;
    [SerializeField] private TMP_Text superBarText;
    public PlayerHealth playerHealth;
    public float secondsPerSuper = 5f;
    private bool canDoSuper = false;


    void Start()
    {
        Invoke(nameof(makeSuperAvailable), secondsPerSuper);
        superBarText.enabled = false;
    }

    void Update()
    {
        var gamepad = Gamepad.current;

        if (canDoSuper)
        {
            if (Input.GetKeyDown(KeyCode.Space) || (gamepad != null && gamepad.bButton.wasPressedThisFrame))
            {


                playerHealth.gainInvincibility();
                playerAnimator.SetBool("isSupering", true);

            }
        }
    }



    private void makeSuperAvailable()
    {

        canDoSuper = true;
    }
    void clearEnemies()
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
            var currentObject = enemiesList[i];
            if (currentObject.name.Contains("SplitComp"))
            {
                currentObject.GetComponent<SplitEnemyHealth>().damageSplit(superDamage);
            }
            else
            {
                currentObject.GetComponent<EnemyHealth>().damageEnemy(superDamage);
            }
        }
        playerAnimator.SetBool("isSupering", false);
        playerHealth.removeInvincibility();
        canDoSuper = false;
        superBarManager.resetBar();
        superBarText.enabled = false;
        Invoke(nameof(makeSuperAvailable), secondsPerSuper);
    }
}
