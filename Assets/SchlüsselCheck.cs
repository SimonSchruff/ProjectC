using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchlüsselCheck : MonoBehaviour
{
    public PickUpObject[] keys = new PickUpObject[3]; 

    public Animator doorA; 

    
    void Update()
    {
        if(keys[0].isSolved == true && keys[1].isSolved == true && keys[2].isSolved == true )
        {
            Debug.Log("All Keys are here"); 
            doorA.SetTrigger("activate"); 
        }
    }
}
