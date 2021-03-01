using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Delicous, grab, step,eat;
    static AudioSource audioSr;
    // Start is called before the first frame update
    void Start()
    {
        Delicous = Resources.Load<AudioClip> ("deli");
        grab = Resources.Load<AudioClip>("Grab");
        step = Resources.Load<AudioClip>("Steps");
        eat = Resources.Load<AudioClip>("ate");

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
            case "Step":
                audioSr.PlayOneShot(step);
                break;

        
        
            case "Delicous":
                audioSr.PlayOneShot(Delicous);
            break;

        
        
            case "Grab":
                audioSr.PlayOneShot(grab);
            break;
            case "Ate":
                audioSr.PlayOneShot(eat);
                break;

        }
    }
}
