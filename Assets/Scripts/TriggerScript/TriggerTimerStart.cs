using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimerStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        EventManager.OnTimerStart();
        Debug.Log("Rentre");
    }
}
