using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jump, hit, shoot,Expo;
    static AudioSource audioSr;
    // Start is called before the first frame update
    void Start()
    {
        jump = Resources.Load<AudioClip> ("Jump");
        hit = Resources.Load<AudioClip>("Hit");
        shoot = Resources.Load<AudioClip>("Shoot");
        Expo = Resources.Load<AudioClip>("expolo");

        audioSr = GetComponent<AudioSource>();
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlayerSound(string clip)
    {
        switch (clip)
        {
            case "shoot":
                audioSr.PlayOneShot(shoot);
                break;

        
        
            case "jump":
                audioSr.PlayOneShot(jump);
            break;

        
        
            case "hit":
                audioSr.PlayOneShot(hit);
            break;
            case "expo":
                audioSr.PlayOneShot(Expo);
                break;

        }
    }
}
