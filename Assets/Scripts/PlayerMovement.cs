using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float Speed = 9f;
    [SerializeField] private float JumpPower = 12f;
    [SerializeField] private float gravityScale;
    [SerializeField] private float fallGravityScale = 15;
    [SerializeField] bool IsGrounded;
    [SerializeField] private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.1f;
    private Vector3 respawnPoint;
    Rigidbody2D rb;
    Vector2 move;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Keybind();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerDeath"))
        {
            transform.position = respawnPoint;
        }
    }

    void Keybind() // In this function we will assign keys to actions

    {
        if (isDashing)
        {
            return;
        }

        //Jump

        
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded == true)
        {
            Jump();
                
        }

        

        //Movement

        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = new Vector2(move.x * Speed, rb.velocity.y);

        if (move.x < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
        if (move.x > 0.01f) transform.localScale = new Vector3(1, 1, 1);


        //Dash

        if (Input.GetKeyDown (KeyCode.LeftAlt) && canDash)
        {
            StartCoroutine(Dash());
        }

    //Code Dash

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        //rb.AddForce(Vector2.right * dashingPower, ForceMode2D.Impulse);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
     }

    void Jump()
        {
            rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            if (rb.velocity.y > 0)
            {
                rb.gravityScale = gravityScale;
            }
            else
            {
                rb.gravityScale = fallGravityScale;
            }
        }

        /*
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime); //Move to the right
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime); //Move to the left
            
        }
        */

    }


}