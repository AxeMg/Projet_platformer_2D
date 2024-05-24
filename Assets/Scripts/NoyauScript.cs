using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoyauScript : MonoBehaviour
{
    public SpriteRenderer boutonY;
    public Animator animator;
    Transform PlayerTransform;
    [SerializeField] private float interactDistance;
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    boutonY.enabled = true;


        
    //}
    void PlayAnim()
    {
        if (Vector2.Distance(PlayerTransform.position, transform.position) < interactDistance && Input.GetButtonDown("Interact"))
        {
            boutonY.enabled = true;

                Debug.Log("Je marche");
                animator.SetBool("Interact", true);
            
        }
    }
    


    private void OnTriggerExit2D(Collider2D other)
    {
        boutonY.enabled = false;
    } 

    // Start is called before the first frame update
    void Start()
    {
        boutonY.enabled = false;
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void BoolSwitch()
    {
        animator.SetBool("Interact", false);
        animator.SetBool("AnimEnd", true);
    }

    private void Update()
    {
        PlayAnim();
    }


}
