using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoyauScript : MonoBehaviour
{
    public SpriteRenderer boutonY;

    private void OnTriggerEnter2D(Collider2D other)
    {
        boutonY.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        boutonY.enabled = false;
    } 

    // Start is called before the first frame update
    void Start()
    {
        boutonY.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
