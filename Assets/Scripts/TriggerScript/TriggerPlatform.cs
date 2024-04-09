using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    PlatformMoving platform;

    private void Start()
    {
        platform = GetComponent<PlatformMoving>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        platform.canMove = true;
    }
}
