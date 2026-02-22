using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugAggression : MonoBehaviour
{
    [SerializeField] private float speedWhenAngry;
    [SerializeField] private float secondsUntilAngry;
    [SerializeField] private EnemyPathFind slugPathFind;
    [SerializeField] private Animator enemyAnimator;

    void Start()
    {
        Invoke(nameof(makeAngry), secondsUntilAngry);
       
    }

    private void makeAngry()
    {
        slugPathFind.followSpeed = speedWhenAngry;
        enemyAnimator.SetBool("isFast",true);

    }
}
