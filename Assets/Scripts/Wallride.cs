using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallride : MonoBehaviour
{
    [SerializeField] private bool isWalled;
    [SerializeField] private float wallSpeed = 10f;
    [SerializeField] private float wallTime = 1.5f;
    private float gravitySave;
    Rigidbody2D rb;
    

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravitySave = rb.gravityScale;

    }

    
    void Update()
    {
        //wallRide();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            isWalled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            isWalled = false;
        }
    }


    public void wallRide()
    {
        if (Input.GetButtonDown("Wallride") && isWalled == true)
        {
            Debug.Log("Wallride");
            StartCoroutine(Wallide());
            
        }
        if (isWalled == false)
        {
            StopCoroutine(Wallide());
            rb.gravityScale = gravitySave;
        }



    }
    IEnumerator Wallide()
    {
        rb.gravityScale = 0.1f;
        rb.velocity = new Vector2(transform.localScale.x * wallSpeed, 0f);
        yield return new WaitForSeconds(wallTime);
        rb.gravityScale = gravitySave;

        
    }
}