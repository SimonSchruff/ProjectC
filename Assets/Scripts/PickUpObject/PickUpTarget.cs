using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTarget : MonoBehaviour
{

    public GameObject item; 

    public void OnTriggerEnter(Collider c)
    {
        //Debug.Log("trigger"); 
        if(c.gameObject.GetComponent<PickUpObject>() != null )
        {
            Debug.Log("Item in Target Area"); 
            item.GetComponent<PickUpObject>().inTargetArea = true; 
        }
    }
}
