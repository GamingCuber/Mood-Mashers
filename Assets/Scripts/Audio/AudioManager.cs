using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicManager;
    [SerializeField] AudioSource SFXManager;

    public AudioClip playerHurt;
    public AudioClip playerHit;

    public AudioClip enemyHurt;

    public AudioClip enemyHit;

    public AudioClip zombieDeath;

    public AudioClip slimeDeath;

    public AudioClip splitDeath;
    public AudioClip XPCollect;

    public void playSound(AudioClip clip)
    {
        SFXManager.PlayOneShot(clip);
    }
}
