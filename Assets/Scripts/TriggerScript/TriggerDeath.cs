using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerDeath : MonoBehaviour
{
    private Vector2 respawnPoint;

    [SerializeField] private float deathTime;

    public ParticleSystem deathFX;

    Rigidbody2D rb;
    Material opacity;
    BoxCollider2D coll;

    [SerializeField] CinemachineImpulseSource screenShake;
    [SerializeField] float powerAmount;

    void Start()
    {
        respawnPoint = transform.position;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        opacity = GetComponent<SpriteRenderer>().material;
    }

    public void Death()
    {
        StartCoroutine(Die());
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

    IEnumerator Die()
    {
        ScreenShake();
        deathFX.Play();
        coll.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        opacity.color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(deathTime);
        coll.enabled = true;
        opacity.color = new Color(1f, 1f, 1f, 1f);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.position = respawnPoint;
    }

    public void ScreenShake()
    {
        screenShake.GenerateImpulse(powerAmount);
    }

}
