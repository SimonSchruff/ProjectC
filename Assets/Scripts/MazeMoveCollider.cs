using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMoveCollider : MonoBehaviour
{

    public MazeDragObject dragObject; 
    void Start()
    {
        
    }

    
   
    void OnTriggerStay(Collider c)
    {
        if(c.gameObject.GetComponent<MazeDragObject>() != null )
        {
            dragObject.canMove = true; 
        }
    }

   
    void OnTriggerExit(Collider c)
    {
        
        if(c.gameObject.GetComponent<MazeDragObject>() != null )
        {
            dragObject.canMove = false; 
        }
    }
}
