using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    //-----------------------------------------------------

    [SerializeField] private float Speed = 9f;
    [SerializeField] private float JumpPower = 12f;
    [SerializeField] private float gravityScale;
    //[SerializeField] private float fallGravityScale = 15;
    [SerializeField] private bool canDash = true;
    [SerializeField] private LayerMask jumpableGround;

    //[SerializeField] private bool isWalled;
    //[SerializeField] private float wallSpeed = 10f;
    //[SerializeField] private float wallTime = 1.5f;

    private bool isDashing;
    [SerializeField] private float dashingPower = 100f;
    [SerializeField] private float dashingTime = 1f;
    private float dashingCooldown = 0.1f;
    private float gravitySave;
    private Vector3 respawnPoint;
    Rigidbody2D rb;
    BoxCollider2D coll;
    Vector2 move;

    //-----------------------------------------------------------------

    //----------------------------------------------------------

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        gravitySave = rb.gravityScale;
        respawnPoint = transform.position;
    }


    void Update()
    {
        Keybind();
    }

    //-------------IsGounded function--------------------------------------

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    //--------------------------------------------------------------------

    //-------------Death function------------------------------------------

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerDeath"))
        {
            transform.position = respawnPoint;
        }
    }

    //---------------------------------------------------------------------------

    //-------------Keybind assignation---------------------------------------------------

    void Keybind()

    {
        
        if(isDashing)
        {
            return;
        }

        //Jump key


        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            Jump();

        }

        //Dash Key

        if (Input.GetKeyDown(KeyCode.R) && canDash)
        {
            StartCoroutine(Dash());
            
        }
        //Lateral movment

        LateralMovment();

    //---------------------------------------------------------------------

    //------------------Left & Right Movement------------------------------

    void LateralMovment()
    {
            if (isDashing)
            {
                return;
            }

        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = new Vector2(move.x * Speed, rb.velocity.y);
        
        //Flip
        if (move.x < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
        if (move.x > 0.01f) transform.localScale = new Vector3(1, 1, 1);
    }
    
    //-----------------------------------------------------------------
        

    }
    //---------------------Dash coroutine-------------------

    IEnumerator Dash()
    {
        
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = gravitySave;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
     }

    //--------------------------------------------------------


    //---------------------Jump function-----------------------

    void Jump()
    {
        rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
    }
            /*
            if (rb.velocity.y > 0)
            {
                rb.gravityScale = gravityScale;
            }
            else
            {
                rb.gravityScale = fallGravityScale;
            }
            */

    //----------------Wallride coroutine--------------  

    //-------------------------------------------------

    


}