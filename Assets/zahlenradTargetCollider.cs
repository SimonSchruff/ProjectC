using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zahlenradTargetCollider : MonoBehaviour
{

    public GameObject compareGO;

    public bool correctPos; 
   
    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject == compareGO)
        {
            correctPos = true ;
        }
    }
    
    void OnTriggerExit(Collider c)
    {
         if(c.gameObject == compareGO)
        {
            correctPos = false ;
        }
    }
}
