using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitInvincibility : MonoBehaviour
{
    [SerializeField] private CircleCollider2D splitCollider;
    [SerializeField] private float secondsOfInvincibility = 1.0f;
    void Start()
    {
        splitCollider.enabled = false;
        Invoke(nameof(removeInvincibility), secondsOfInvincibility);
    }

    private void removeInvincibility()
    {
        splitCollider.enabled = true;
    }

}
