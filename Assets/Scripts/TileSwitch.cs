using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
//using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using UnityEngine;

public class TileSwitch : MonoBehaviour
{

    public GameObject Light_red;
    public GameObject Light_green;
    private bool solActive ;
    public GameObject Sol_1;
    public GameObject Sol_2;

    // Start is called before the first frame update
    void Start()
    {
        Sol_1.SetActive(true);
        Light_green.SetActive(true);
        Sol_2.SetActive(false);
        Light_red.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Key();

        
    }

    private void Mecha()

    {


        if (solActive)
        {
            Sol_1.SetActive(true);
            Light_green.SetActive(true);
            Sol_2.SetActive(false);
            Light_red.SetActive(false);
            }
        else
        {
            Sol_1.SetActive(false);
            Light_green.SetActive(false);
            Sol_2.SetActive(true);
            Light_red.SetActive(true);
        }
            
        solActive = !solActive;


    }

    private void Key()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Mecha();
        }
    }

}
