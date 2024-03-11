using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
//using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using UnityEngine;

public class TileSwitch2 : MonoBehaviour
{
    private TilemapRenderer tileMap2;
    private TilemapCollider2D tileCo2;
    private bool lightActive;
    public GameObject lightSwitch;


    // Start is called before the first frame update
    void Start()
    {
        tileMap2 = GetComponent<TilemapRenderer>();
        tileCo2 = GetComponent<TilemapCollider2D>();
        tileMap2.enabled = false;
        tileCo2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        Mecha2();
    }

    public void Mecha2()

    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (lightActive)
            {
                lightSwitch.SetActive(true);
            }
            else
            {
                lightSwitch.SetActive(false);
            }
            lightActive = !lightActive;
            tileMap2.enabled = !tileMap2.enabled;
            tileCo2.enabled = !tileCo2.enabled;
        }
    }
}