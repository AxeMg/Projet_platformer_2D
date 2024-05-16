using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimerStop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        EventManager.OnTimerStop();
        Debug.Log("Rentre");
    }
}
