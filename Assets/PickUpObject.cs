using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public bool currentlySelected; 

    [Header("PickUp")]
    Vector3 originalPos;
    private bool isPickUp = false;
    private Vector3 mouseOffset;
    private float mouseZCoord;


    public void Start()
    {
        originalPos = transform.position; 
    }


    private void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //Store offset = GameObject world pos - mouse world pos
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

        currentlySelected = false;
        transform.position = originalPos;
    }
}
