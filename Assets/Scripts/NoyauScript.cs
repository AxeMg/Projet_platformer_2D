using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoyauScript : MonoBehaviour
{
    public SpriteRenderer boutonY;
    public Animator animator;
    public GameObject platformDestructible;
    Transform PlayerTransform;
    [SerializeField] private float interactDistance;
    [SerializeField] CinemachineImpulseSource screenShake;
    [SerializeField] private float powerAmount;

    void PlayAnim()
    {
        if (Vector2.Distance(PlayerTransform.position, transform.position) < interactDistance && Input.GetButtonDown("Interact"))
        {
            ScreenShake();
            animator.SetBool("Interact", true);
            StartCoroutine(SolDestruction());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
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
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void BoolSwitch()
    {
        animator.SetBool("Interact", false);
        animator.SetBool("AnimEnd", true);
    }
    public void ScreenShake()
    {
        screenShake.GenerateImpulse(powerAmount);
    }


    private void Update()
    {
        PlayAnim();
    }

    IEnumerator SolDestruction()
    {
        yield return new WaitForSeconds(6f);
        platformDestructible.SetActive(false);
    }


}
