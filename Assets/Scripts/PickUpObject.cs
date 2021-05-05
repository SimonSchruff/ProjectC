using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public bool currentlySelected; 

    [Header("PickUp")]
    public Vector3 originalPos;
    private Vector3 mouseOffset;
    private float mouseZCoord;

    public Transform parentPos; 


    public void Start()
    {
        originalPos = transform.position; 
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

        transform.position = GetMouseWorldPos() + mouseOffset + new Vector3(0,0,-1);
    }
    private void OnMouseUp()
    {

        currentlySelected = false;
        transform.position = parentPos.position; 
    }
}
