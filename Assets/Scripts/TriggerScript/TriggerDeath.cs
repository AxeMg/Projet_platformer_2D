using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerDeath : MonoBehaviour
{
    private Vector2 respawnPoint;
    private Material glowMat;

    private float apparitionAmount;
    private float apparitionSpeed;

    void Start()
    {
        respawnPoint = transform.position;
        glowMat = GetComponent<Material>();
    }

    public void Death()
    {
        transform.position = respawnPoint;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerDeath"))
        {
            Death();
        }

        if(other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;
           

        }
    }

}
