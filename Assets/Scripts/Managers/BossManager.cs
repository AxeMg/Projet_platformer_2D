using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

    public Animator porteHaut;
    public Animator porteBas;
    [SerializeField] private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        //porteHaut = GetComponent<Animator>();
        //porteBas = GetComponent<Animator>();
        porteBas.enabled = false;
        porteHaut.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if ( isOpen)
        //{
        //    Debug.Log("Ouvre");
        //    porteBas.Play("ANIM_MurHaut");
        //    porteBas.Play("ANIM_MurBas");
        //}
    }

    public void OuverturePorte()
    {
        isOpen = true;
        porteBas.enabled = true;
        porteHaut.enabled = true;
    }


}
