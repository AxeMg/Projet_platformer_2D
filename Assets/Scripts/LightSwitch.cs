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
        
    }

    // Update is called once per frame
    void Update()
    {
        Switch();
    }

    void Switch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
