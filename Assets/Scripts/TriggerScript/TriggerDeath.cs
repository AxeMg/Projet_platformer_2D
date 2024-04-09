using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerDeath : MonoBehaviour
{
    private Vector2 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerDeath"))
        {
            transform.position = respawnPoint;
        }
        else if(other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;
        }
    }

}
