using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TriggerStatueChackpoint : MonoBehaviour
{
    public Light2D lights1;
    public Light2D lights2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        lights1.intensity = 50;
        lights2.intensity = 50;
    }
}
