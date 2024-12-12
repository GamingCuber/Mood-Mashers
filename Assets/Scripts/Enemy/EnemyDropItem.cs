using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class EnemyDropItem : MonoBehaviour
{

    public GameObject XP;
    public GameObject pie;
    private float randomizer;
    [SerializeField] private float probabilityOfXP;
    public void dropItem()
    {
        randomizer = Random.Range(0f, 1f);
        if (randomizer <= probabilityOfXP)
        {
            Instantiate(XP, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(pie, transform.position, Quaternion.identity);
        }

    }
}
