using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TriggerStatueChackpoint : MonoBehaviour
{
    public Light2D lights1;
    public Light2D lights2;

    private Material glowMat;

    private float apparitionAmount;
    private float apparitionSpeed;
    [SerializeField] private bool apparitionCkeck;

    private bool isActived = true;


    [SerializeField] private AudioClip checkpointSoundClip;

    private void Start()
    {
        glowMat = GetComponent<SpriteRenderer>().material;
    }


    private void Update()
    {
        if (apparitionCkeck == true)
        {
            apparitionAmount = Mathf.Clamp01(apparitionAmount + apparitionSpeed * Time.deltaTime);
            glowMat.SetFloat("_ApparitionAmount", apparitionAmount);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //lights1.intensity = Mathf.Clamp(lights1.intensity * Time.deltaTime,0f,50f);
        StartApparition(1f);
       
    }

    private void StartApparition(float apparitionSpeed)
    {
        if (isActived)
        {
            SoundFXManager.instance.PlaySoundEffectClip(checkpointSoundClip, transform, 1f);
            apparitionCkeck = true;
            this.apparitionSpeed = apparitionSpeed;
            isActived = false;
        }

    }
}
