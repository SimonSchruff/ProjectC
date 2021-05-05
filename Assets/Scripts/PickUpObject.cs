using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public bool currentlySelected;
    public bool inTargetArea; 

    [Header("PickUp")]
    private Vector3 mouseOffset;
    private float mouseZCoord;

    public Transform originalPos;
    public Transform targetPos; 


    public void Start()
    {
        
    }

    private void Update()
    {
        
    }


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
            transform.position = targetPos.position; 
        }
        
    }
}
