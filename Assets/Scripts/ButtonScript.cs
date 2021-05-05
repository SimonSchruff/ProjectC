using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    MeshRenderer meshR;
    Animator animator;

    public bool currentlySelected;
    public Material whiteMat;
    public Material redMat; 


    private void Start()
    {
        meshR = GetComponent<MeshRenderer>();
        animator = GetComponent<Animator>();
    }

    //Gets called from player Input
    public void OnClicked()
    {

        if (currentlySelected == false)
        {
            if (whiteMat != null)
                meshR.material = whiteMat;


        }
        else
        {
            if (redMat != null)
                meshR.material = redMat;


            if (CompareTag("Button01"))
            {
                animator.SetTrigger("activate");
            }
            else if (CompareTag("Button02"))
            {

            }
            
        }
    }
}
