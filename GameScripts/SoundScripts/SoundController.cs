using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    public AudioSource audioSource;

    public AudioSource[] soundEffects;


    public AudioClip GameWinSound;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    


    public void sesEfektiCikarFNC(int hangiSes)
    {
        soundEffects[hangiSes].Stop();
        soundEffects[hangiSes].Play();
    }

    public void GameWin()
    {
        audioSource.PlayOneShot(GameWinSound);
    }
}
