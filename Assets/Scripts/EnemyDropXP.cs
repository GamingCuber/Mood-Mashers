using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropXP : MonoBehaviour
{

    public GameObject XP;

    public void dropXP()
    {
        Instantiate(XP, transform.position, Quaternion.identity);
    }
}
