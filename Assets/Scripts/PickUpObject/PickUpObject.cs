using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [Header("Public Bools")]
    public bool currentlySelected;
    public bool inTargetArea; 
    public bool isSolved; 

    //Mouse pos calculations
    private Vector3 mouseOffset;
    private float mouseZCoord;


    [Header("Original and Target Transforms")]
    public Transform originalPos;
    public Transform targetPos; 


    [Header("External References")]
    public GameObject[] gameObjects;
    public Animator animator; 

    


    public void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //Save offset = GameObject world pos - mouse world pos
        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        //x,y coordinates 
        Vector3 mousePoint = Input.mousePosition;


        //z coordinate of gameobject on screen
        mousePoint.z = mouseZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    private void OnMouseDrag()
    {
        
        transform.position = GetMouseWorldPos() + mouseOffset;
    }


    private void OnMouseUp()
    {
        if(!inTargetArea)
        {
            currentlySelected = false;
            transform.position = originalPos.position;
        }
        else
        {
            //Pick UP object has reaches target
            isSolved = true; 

            transform.position = targetPos.position; 

            if(animator != null)
                animator.SetTrigger("activate"); 


            foreach(GameObject go in gameObjects)
            {
                if(go.activeInHierarchy == false)
                {
                    go.SetActive(true);  
                }
                else
                {
                    go.SetActive(false); 
                }
            }  
        }
        
    }
}
