using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropXP : MonoBehaviour
{

    public GameObject XP;
    [SerializeField] public float XPDropped; 
    
    public void dropXP()
    {
        Instantiate(XP, transform.position, Quaternion.identity);
    }
}
