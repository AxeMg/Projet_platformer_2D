using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStopMusic : MonoBehaviour
{

    public AudioSource musicPrincipale;
    public AudioSource musicSalleNoyau;

    private void OnTriggerEnter2D(Collider2D other)
    {
        musicPrincipale.Stop();
        musicSalleNoyau.Play();
    }

}
