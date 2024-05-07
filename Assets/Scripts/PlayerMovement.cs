using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    //-----------------------------------------------------

    [SerializeField] private float Speed = 9f;
    [SerializeField] private float JumpPower = 12f;
    [SerializeField] private float gravityScale;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private bool isWalled;
    private bool isAttach;
    [SerializeField] private float wallSpeed;
    [SerializeField] private float wallTime = 1.5f;
    private bool canWall = true;

    private bool isDashing;
    private bool canDash = true;
    [SerializeField] private float dashingPower = 100f;
    [SerializeField] private float dashingTime = 1f;
    [SerializeField] private float dashingCooldown = 0.5f;

    private float gravitySave;
    Rigidbody2D rb;
    BoxCollider2D coll;
    Vector2 move;

    [SerializeField] private float coyoteTime = 0.05f;
    private float coyoteTimeCounter;

    public Animator animator;
    private float horizontalMove = 0f;

    public Ghost ghost;

    [SerializeField] private AudioClip jumpSoundClip;
    [SerializeField] private AudioClip dashSoundClip;
    [SerializeField] private AudioClip landSoundClip;

    public GameObject direction;

    public ParticleSystem FX_Wallride;
    public ParticleSystem FX_Wallride1;

    //-----------------------------------------------------------------

    //--------------Start--------------------------------------------

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

        if(IsGrounded() || isAttach)
        {
            coyoteTimeCounter = coyoteTime;
            animator.SetBool("Jump", false);
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
            animator.SetBool("Jump", true);
        }

        if (Input.GetButtonDown("JumpCustom") && coyoteTimeCounter > 0f )
        {
            Debug.Log("Sauuute");
            Jump();
            isAttach = false;
        }

        //Dash Key

        if (Input.GetButtonDown("Dash") && canDash)
        {
            Debug.Log("Dash");
            SoundFXManager.instance.PlaySoundEffectClip(dashSoundClip, transform, 1f);
            StartCoroutine(Dash());  
        }
        //Deplacment Key

        LateralMovment();

        //Wallride key

        if (Input.GetButtonDown("Wallride") && isWalled && canWall)
        {
            Debug.Log("Wallride");
            StartCoroutine(Wallide());
            FX_Wallride.Play();
            FX_Wallride1.Play();
            animator.SetBool("Wallride", true);
        }  
    }

    //---------------------------------------------------------------------

    //------------------Left & Right Movement------------------------------

    void LateralMovment()
    {
        if (isDashing || isAttach)
        {
            return;
        }

        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        horizontalMove = Input.GetAxisRaw("Horizontal") * Speed;
        //rb.AddForce(move, 0f );
        rb.velocity = new Vector2(move.x * Speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));



        //Flip

        //if (move.x < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
        //if (move.x > 0.01f) transform.localScale = new Vector3(1, 1, 1);

        if (move.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            direction.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (move.x > 0f) 
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            direction.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //-----------------------------------------------------------------

    //---------------------Dash coroutine-------------------

    IEnumerator Dash()
    {
        animator.SetBool("Dash", true);
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0f;
        ghost.makeGhost = true;
        rb.velocity = new Vector2(direction.transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        animator.SetBool("Dash", false);
        ghost.makeGhost = false;
        rb.gravityScale = gravitySave;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        
    }

    //--------------------------------------------------------


    //---------------------Jump function-----------------------

    void Jump()
    {
        SoundFXManager.instance.PlaySoundEffectClip(jumpSoundClip, transform, 1f);
        rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);   
    }

    //----------------Wallride Mechanic--------------  
   

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
            Debug.Log("Je sors du mur");
            FX_Wallride.Stop();
            FX_Wallride1.Stop();
            animator.SetBool("Wallride", false);
            isWalled = false;
            StopCoroutine(Wallide());
            rb.gravityScale = gravitySave;
            isAttach = false;
            canWall = true;
        }
    }

    IEnumerator Wallide()
    {
        Debug.Log("Debut wallride");
        canWall = false;
        isAttach = true;
        rb.gravityScale = 0.4f;
        rb.velocity = new Vector2(direction.transform.localScale.x * wallSpeed, 0f);
        yield return new WaitForSeconds(wallTime);
        canWall = true;
        yield break;
    }
}
    //-------------------------------------------------




