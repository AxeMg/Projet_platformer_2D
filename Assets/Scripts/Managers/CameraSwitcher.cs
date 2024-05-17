using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera camPlayer;
    public CinemachineVirtualCamera[] virtualCameras;

    public string triggerTag;

    // Start is called before the first frame update
    void Start()
    {
       SwitchToCamera(camPlayer); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggerTag))
        {
            CinemachineVirtualCamera targetCamera = other.GetComponentInChildren<CinemachineVirtualCamera>();
            SwitchToCamera(targetCamera);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       if(other.CompareTag(triggerTag))
        {
            SwitchToCamera(camPlayer);
        } 
    }

    private void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach(CinemachineVirtualCamera camera in virtualCameras)
        {
            camera.enabled = camera == targetCamera;
        }
    }
}
