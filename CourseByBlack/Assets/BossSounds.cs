using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSounds : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] clips;
    public float timebtwsoundeffects;
    public float nextsfxtime;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        if (Time.time >= nextsfxtime)
        {
            int randomNumb = Random.Range(0, clips.Length);
            source.clip = clips[randomNumb];
            source.Play();
            nextsfxtime = Time.time + timebtwsoundeffects;
        }
    }
}

