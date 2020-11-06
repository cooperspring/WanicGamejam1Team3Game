////By Jacob Sims
////11/6/2020
////Master audio managment script for project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    public static AudioClip playerHitSound, harpoonShotSound, flareShotSound;
    static AudioSource audioSrc;

    // Start is called before the first frame updated w
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("sharkhit4");
        audioSrc = GetComponent<AudioSource>();

        harpoonShotSound = Resources.Load<AudioClip>("harpoonshot");
        audioSrc = GetComponent<AudioSource>();

        flareShotSound = Resources.Load<AudioClip>("flareshot");
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            
            case "harpoonShot":
                audioSrc.PlayOneShot(harpoonShotSound);
                break;

            case "flareShot":
                audioSrc.PlayOneShot(flareShotSound);
                break;
        }
    }
     
}
