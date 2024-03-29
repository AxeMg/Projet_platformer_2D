using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    //-----------------------------------------------------

    public Wallride wallride;

    [SerializeField] private float Speed = 9f;
    [SerializeField] private float JumpPower = 12f;
    [SerializeField] private float gravityScale;
    //[SerializeField] private float fallGravityScale = 15;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private bool isWalled;
    [SerializeField] private float wallSpeed = 10f;
    [SerializeField] private float wallTime = 1.5f;

    private bool isDashing;
    [SerializeField] private bool canDash = true;
    [SerializeField] private float dashingPower = 100f;
    [SerializeField] private float dashingTime = 1f;
    private float dashingCooldown = 0.1f;

    private float gravitySave;
    Rigidbody2D rb;
    BoxCollider2D coll;
    Vector2 move;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;


    //-----------------------------------------------------------------

    //----------------------------------------------------------

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        gravitySave = rb.gravityScale;
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
 
    //---------------------------------------------------------------------------

    //-------------Keybind assignation---------------------------------------------------

    void Keybind()

    {
        
        if(isDashing)
        {
            return;
        }

        //Jump key

        if(IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("JumpCustom") && coyoteTimeCounter > 0f)
        {
            Jump();

        }

        //Dash Key

        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(Dash());
            
        }
        //Lateral movment

        LateralMovment();

        //Wallride key

        if (Input.GetButtonDown("Wallride") && isWalled)
        {
            Debug.Log("Wallride");
            StartCoroutine(Wallide());

        }
        


        //---------------------------------------------------------------------

       
        

    }

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

    //----------------Wallride coroutine--------------  
   

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
            StopCoroutine(Wallide());
           //rb.gravityScale = gravitySave;
        }
    }

    /*
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
    */
    IEnumerator Wallide()
    {
        rb.gravityScale = 0.1f;
        rb.velocity = new Vector2(transform.localScale.x * wallSpeed, 0f);
        yield return new WaitForSeconds(wallTime);
        rb.gravityScale = gravitySave;


    }
}
    //-------------------------------------------------




