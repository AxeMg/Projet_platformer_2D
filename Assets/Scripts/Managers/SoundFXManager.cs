using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundEffectClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in ganeObject

        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign the audioClip

        audioSource.clip = audioClip;

        //assign volume

        audioSource.volume = volume;

        //play sound

        audioSource.Play();

        //get lenght of sound FX clip

        float clipLenght = audioSource.clip.length;

        //detroy the clip after is done playing

        Destroy(audioSource.gameObject,clipLenght);
    }
}
