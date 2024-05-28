using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreenScript : MonoBehaviour
{

    private float transparence;
    public bool fadeOut;
    [SerializeField] private float step;

    // Start is called before the first frame update
    void Start()
    {
        transparence = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Fade();
    }

    private void Fade()
    {
        transparence = Mathf.Clamp(transparence,0,1);

        if (fadeOut)
        {
            transparence += step;
        }
        else
        {
            transparence -= step;
        }

        GetComponent<CanvasGroup>().alpha = transparence;
    }
}
