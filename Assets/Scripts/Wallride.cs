using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallride : MonoBehaviour
{
    [SerializeField] bool isWalled;
    private float wallSpeed = 9f;
    private float wallTime = 2f;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        wallRide();
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


    private void wallRide()
    {
        //float originalGravity = rb.gravityScale;
        if (Input.GetKeyDown(KeyCode.E) && isWalled == true)
        {
            StartCoroutine(Wallide());
        }
        if (isWalled == false)
        {
            StopCoroutine(Wallide());
            rb.gravityScale = 5f;
        }
    }
    IEnumerator Wallide()
    {
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0.1f;
        rb.velocity = new Vector2(transform.localScale.x * wallSpeed, 0f);
        yield return new WaitForSeconds(wallTime);
        //rb.gravityScale = 0.1f;
        //rb.gravityScale = originalGravity;    
    }
}