using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect: MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip swordAttack;
    public AudioClip ShieldAttack;
    public AudioClip Buff2;
    public AudioClip Buff1;
    public AudioClip Running;

    void Start()
    {
        audioSource.Play();
    }


    void Update()
    {
        
    }
    void RunningSound()
    {
        audioSource.PlayOneShot(Running);
    }
    void AttackSound()
    {
        audioSource.PlayOneShot(swordAttack);
    }
    void ShieldSound()
    {
        audioSource.PlayOneShot(ShieldAttack);
    }
    void Buff1Sound()
    {
        audioSource.PlayOneShot(Buff1);
    }
    void Buff2Sound()
    {
        audioSource.PlayOneShot(Buff2);
    }
}
