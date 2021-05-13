using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTarget : MonoBehaviour
{

    public GameObject item; 

    public GameObject targetIndicator; 

    public void OnTriggerEnter(Collider c)
    {
        //Debug.Log("trigger"); 
        if(c.gameObject.GetComponent<PickUpObject>() != null )
        {
            Debug.Log("Item in Target Area"); 
            targetIndicator.SetActive(true); 
            item.GetComponent<PickUpObject>().inTargetArea = true; 
        }
    }

   
    void OnTriggerExit(Collider c)
    {
        if(c.gameObject.GetComponent<PickUpObject>() != null )
        {
            item.GetComponent<PickUpObject>().inTargetArea = false; 
            if(targetIndicator != null) 
                targetIndicator.SetActive(false); 
        }
    }

   
    void Update()
    {
        if(item.gameObject.GetComponent<PickUpObject>() != null)
        {
            if(item.gameObject.GetComponent<PickUpObject>().isSolved == true)
            {
                if(targetIndicator != null) 
                    targetIndicator.SetActive(false); 
            }
        }
    }
}
