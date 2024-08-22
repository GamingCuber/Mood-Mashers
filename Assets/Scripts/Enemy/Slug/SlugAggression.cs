using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugAggression : MonoBehaviour
{
    [SerializeField] private float speedWhenAngry;
    [SerializeField] private float secondsUntilAngry;
    [SerializeField] private EnemyPathFind slugPathFind;
    void Start()
    {
        Invoke(nameof(makeAngry), secondsUntilAngry);
    }

    private void makeAngry()
    {
        slugPathFind.followSpeed = speedWhenAngry;
    }
}
