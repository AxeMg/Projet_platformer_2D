using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using UnityEngine;

public class TileSwitch : MonoBehaviour
{
    private TilemapRenderer tileMap;
    private TilemapCollider2D tileCo;
    private bool lightActive ;
    public GameObject lightSwitch2;

    // Start is called before the first frame update
    void Start()
    {
        tileMap = GetComponent<TilemapRenderer>();
        tileCo = GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Mecha();
    }

    public void Mecha()

    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (lightActive)
            {
                lightSwitch2.SetActive(false);
            }
            else
            {
                lightSwitch2.SetActive(true);
            }
            lightActive = !lightActive;
            tileMap.enabled = !tileMap.enabled;
            tileCo.enabled = !tileCo.enabled;
        }
/*
        if (reality == true)
        {
            tileMap.enabled = true;
        }

        if (reality == false) 
        { 
            tileMap.enabled = false; ;
        }
*/
    }
}
