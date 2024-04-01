using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{

    public GameObject RED;
    public GameObject GREEN;
    private bool lightActive;

    // Start is called before the first frame update
    void Start()
    {
        RED.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Switch();
    }

    private void Switch()
    {
        if (Input.GetButtonDown("SwitchPlatform"))
        {
            if (lightActive)
            {
                RED.SetActive(false);
                GREEN.SetActive(true);
            }
            else
            {
                GREEN.SetActive(false);
                RED.SetActive(true);
            }
            lightActive = !lightActive;
        }
    }
}
