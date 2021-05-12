using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlateDrag : MonoBehaviour
{
    public GameObject parentObject;
    private float mouseZCoord;
    

    [Header("Bounds")]
    Vector3 originalPos;

    [Tooltip("Max/Min Bounds according to resulting movementVector.y of mouse position")]
    public Vector3 movementVector;

    public float maxBounds;
    public float minBounds; 



    CubeRotation cubeRotation; 


    //TO-Do:
    //Clamp up and down movement
    //What to do when mouse button is released?


    private void Start()
    {
        cubeRotation = FindObjectOfType<CubeRotation>(); 
    }


    public void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //saves original pos of gameObject parent for movement Vector on mouse click; 
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
        cubeRotation.isDisabled = true; 
        //Clamp Y MovementVector to max/min Bounds; 
        Vector3 moveVectorClamped = new Vector3(GetMovementVector().x,Mathf.Clamp(GetMovementVector().y,originalPos.y - minBounds, originalPos.y + maxBounds),GetMovementVector().z);  
        parentObject.transform.position = moveVectorClamped; 
    
    }

    private void OnMouseUp()
    {
        cubeRotation.isDisabled = false; 
        parentObject.transform.position = originalPos; 
    }
}
