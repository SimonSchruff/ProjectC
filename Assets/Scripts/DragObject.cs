using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public GameObject parentObject;
    private float mouseZCoord;
    private Vector3 movementVector;
    public Vector3 currentPos; 

    [Header("Positions")]
    Vector3 originalPos;
    public float maxBounds;


    //TO-Do:
    //Clamp up and down movement
    //What to do when mouse button is released?


    private void Start()
    {

    }


    private void Update()
    {
        currentPos = parentObject.transform.position;
        
    }

    public void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //saves original pos of gameObject parent for movement Vector; 
        originalPos = parentObject.transform.position;

    }

    private Vector3 GetMouseWorldPos()
    {
        //x,y coordinates 
        Vector3 mousePoint = Input.mousePosition;


        //z coordinate of gameobject on screen
        mousePoint.z = mouseZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    private Vector3 GetMovementVector()
    {
        movementVector = new Vector3(originalPos.x, GetMouseWorldPos().y, originalPos.z);
        return movementVector; 
    }



    private void OnMouseDrag()
    {
        //Object moves out of bounds and is not able to move after
        //if (currentPos.y >= -.27)
        {
            //if (currentPos.y <= -.18)
            {
                //Debug.Log("CanMove");
                parentObject.transform.position = GetMovementVector();
            }

        }
        
    }

    private void OnMouseUp()
    {
        //go back to original pos?
    }
}
