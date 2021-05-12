using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlateDrag : MonoBehaviour
{
    public GameObject parentObject;
    private float mouseZCoord;
    

    [Header("Bounds")]
    private Vector3 originalPos;

    public Vector3 currentPos; 
    public Vector3 targetPos; 
    private float targetRadius; 

    public bool isSolved; 



    public Vector3 movementVector;

    public float maxBounds;
    public float minBounds; 



    CubeRotation cubeRotation; 



    private void Start()
    {
        cubeRotation = FindObjectOfType<CubeRotation>(); 
    }

    private void Update()
    {
        
    }

    public void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //saves original pos of gameObject parent for movement Vector on mouse click; 
        originalPos = transform.position;

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
        movementVector = new Vector3(GetMouseWorldPos().x, originalPos.y, originalPos.z);
        return movementVector; 
    }



    private void OnMouseDrag()
    {
        cubeRotation.isDisabled = true; 
        //Clamp Y MovementVector to max/min Bounds; 
        Vector3 moveVectorClamped = new Vector3(Mathf.Clamp(GetMovementVector().x,originalPos.y - minBounds, originalPos.y + maxBounds),GetMovementVector().y,GetMovementVector().z);  
        transform.position = moveVectorClamped; 
    
    }

    private void OnMouseUp()
    {
        cubeRotation.isDisabled = false; 
        //transform.position = originalPos; 
    }
}
