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

    public bool isDead;

    [SerializeField] CinemachineImpulseSource screenShake;
    [SerializeField] float powerAmount;

    [SerializeField] private AudioClip deathSound;

    //public LaserGunBossFight laserBoss;
    [SerializeField] private Transform[] listeLaser;

    void Start()
    {
        respawnPoint = transform.position;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        opacity = GetComponent<SpriteRenderer>().material;
        
    }

    void Update()
    {

        if (isDead)
        {
            //laserBoss.b_lineRenderer.enabled = false;
            StartCoroutine(Die());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerDeath"))
        {
            isDead = true;
        }

        if(other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;
        }
    }

    IEnumerator Die()
    {
        isDead = false;
        ScreenShake();
        SoundFXManager.instance.PlaySoundEffectClip(deathSound, transform, 1f);
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
        //ListLaser();
    }

    public void ScreenShake()
    {
        screenShake.GenerateImpulse(powerAmount);
    }

    //public void ListLaser()
    //{
        
        
    //        foreach(var Laser in listeLaser)
    //        {
    //            Debug.Log("sdfsefzedfqzsd");
    //            Laser.GetComponent<LaserGunBossFight>().CantShoot();
    //        }
        
    //}

}
