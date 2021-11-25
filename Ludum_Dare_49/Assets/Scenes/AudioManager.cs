﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager ad;
    public Sound[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Sound zounds in sounds)
        {
            zounds.abs = gameObject.AddComponent<AudioSource>();
            zounds.abs.clip = zounds.clip;
            zounds.abs.loop = zounds.Loop;
        }
        Playsound("Main");

    }
    public void Playsound(string name)
    {
        foreach (Sound zounds in sounds)
        {
            if (zounds.name == name)
            {
                zounds.abs.Play();
        }
        }
        
    }
    private void Awake()
    {
        if (ad != null && ad != this)
        {
            Destroy(this.gameObject);
            return;
        }
        ad = this;
        DontDestroyOnLoad(this);
    }
}

