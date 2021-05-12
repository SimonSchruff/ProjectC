using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZahlenradCheck : MonoBehaviour
{
    public Animator schubladeAnim; 

    public zahlenradTargetCollider collider01; 
    public zahlenradTargetCollider collider02; 

    
    void Update()
    {
        if(collider01.correctPos == true && collider02.correctPos == true )
        {
            schubladeAnim.SetTrigger("activate"); 
        }
    }


    

    
}
