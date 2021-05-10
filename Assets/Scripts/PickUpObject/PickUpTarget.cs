using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTarget : MonoBehaviour
{

    public GameObject item; 

    private void OnTriggerEnter(Collider c)
    {
        if(c.CompareTag("PickUp01"))
        {
            Debug.Log("Item in Target Area"); 
            item.GetComponent<PickUpObject>().inTargetArea = true; 
        }
    }
}
