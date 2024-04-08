using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dissolve : MonoBehaviour
{
    public Material materialSol1;
    public Material materialSol2;

    public float dissolveAmount;
    public float dissolveAmount2;
    private float dissolveSpeed;
    [SerializeField] private bool isDissolving;
    [SerializeField] private bool isDissolving2;

    private void Update()
    {

        if (isDissolving)
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount + dissolveSpeed * Time.deltaTime);
            materialSol1.SetFloat("_DissolveAmount", dissolveAmount);
        }
        
        else
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount - dissolveSpeed * Time.deltaTime);
            materialSol1.SetFloat("_DissolveAmount", dissolveAmount);
        }

        if (isDissolving2)
        {         
            dissolveAmount2 = Mathf.Clamp01(dissolveAmount2 + dissolveSpeed * Time.deltaTime); 
            materialSol2.SetFloat("_DissolveAmount", dissolveAmount2);
        }

        else
        {    
            dissolveAmount2 = Mathf.Clamp01(dissolveAmount2 - dissolveSpeed * Time.deltaTime);
            materialSol2.SetFloat("_DissolveAmount", dissolveAmount2);
        }
    }
    

    public void StartDissolve(float dissolveSpeed)
    {
        isDissolving = true;
        this.dissolveSpeed = dissolveSpeed;
    }

    public void StopDissolve(float dissolveSpeed) 
    { 
        isDissolving = false;
        this.dissolveSpeed = dissolveSpeed;
    }

    public void StartDissolve2(float dissolveSpeed)
    {
        isDissolving2 = true;
        this.dissolveSpeed = dissolveSpeed;
    }

    public void StopDissolve2(float dissolveSpeed)
    {
        isDissolving2 = false;
        this.dissolveSpeed = dissolveSpeed;
    }


}

