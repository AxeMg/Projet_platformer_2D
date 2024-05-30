using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    PlatformMoving platform;
    public BoxCollider2D murDroite;
    public BoxCollider2D murGauche;


    private void Start()
    {
        platform = GetComponent<PlatformMoving>();
        murDroite.enabled = false;
        murGauche.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        platform.canMove = true;
        StartCoroutine(MurApparition());
    }

    IEnumerator MurApparition()
    {
        murDroite.enabled = true;
        murGauche.enabled = true;
        yield return new WaitForSeconds(3f);
        murDroite.enabled = false;
        murGauche.enabled = false;

    }
}
