using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerFadeIn : MonoBehaviour
{
    public FadeScreenScript fade;


    private void OnTriggerEnter2D(Collider2D other)
    {
        fade.fadeOut = true;
    }
}
