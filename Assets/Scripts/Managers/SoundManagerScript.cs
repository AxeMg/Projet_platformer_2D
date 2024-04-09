using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, dashSound, tileSwitchSound, wallrideSound, deplacementSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jumpSound");
        dashSound = Resources.Load<AudioClip>("dashSound");
        tileSwitchSound = Resources.Load<AudioClip>("tileSwitchSound");
        wallrideSound = Resources.Load<AudioClip>("wallrideSound");
        deplacementSound = Resources.Load<AudioClip>("deplacementSound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "jumpSound":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "dashSound":
                audioSrc.PlayOneShot(dashSound);
                break;
            case "tileSwitchSound":
                audioSrc.PlayOneShot(tileSwitchSound);
                break;
        }
    }
}
