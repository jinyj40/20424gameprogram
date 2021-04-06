﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    private AudioSource audioSource;

    public AudioClip background;
    public AudioClip hitSound;
    public AudioClip attackSound;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance!=this){
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = background;

        audioSource.volume = 1.0f;
        audioSource.loop = true;
        audioSource.mute = false;

        audioSource.Play();
    }
    public void AttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }
}
