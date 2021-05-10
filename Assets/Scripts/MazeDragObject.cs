using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDragObject : MonoBehaviour
{
    //Pushable Refers to pushable Objects in maze
    

    private float mouseZCoord; 


    private Vector3 originalPos; 
    public Vector3 movementVector; 

    CubeRotation cubeRotation; 

    void Start()
    {
        cubeRotation = FindObjectOfType<CubeRotation>(); 
    }

    
    void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //saves original pos of gameObject parent for movement Vector on mouse click; 
        originalPos = gameObject.transform.position;
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
        
        gameObject.transform.position = GetMouseWorldPos(); 
    }
}
