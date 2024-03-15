using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiStuck : MonoBehaviour
{

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("AntiStuckBox"))
        {
            rb.velocity = new Vector2(transform.localScale.y * 4, 0f);
        }
    }
}
