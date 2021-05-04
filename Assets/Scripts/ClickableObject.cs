using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private MeshRenderer meshR;
    [SerializeField] Material redMat;
    [SerializeField] Material whiteMat; 

    public bool currentlySelected;

    // ------ NOTES --------
    //
    // Different Interactables with overrides of class?


    private void Start()
    {
        meshR = GetComponent<MeshRenderer>(); 
    }

    //Gets called from player Input
    public void OnClicked()
    {
        
        if(currentlySelected == false)
        {
            meshR.material = whiteMat;
        }
        else
        {
            meshR.material = redMat; 
        }
    }
}
