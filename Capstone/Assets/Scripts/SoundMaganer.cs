using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bulletSound;
    static AudioSource audioSrc;

    void Start ()
    {
        bulletSound = Sound.Load<AudioClip> ("270343__littlerobotsoundfactory__shoot-01");

        audioSrc = GetComponent<AudioSource>();

    }



    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "bulletSound":
                audioSrc / PlayOneShot(bulletSound);
                break;
        }
    }
    }
    

    
   

