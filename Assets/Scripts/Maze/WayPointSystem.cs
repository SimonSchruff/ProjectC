using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointSystem : MonoBehaviour
{
    public GameObject[] wayPoints; 

    private int current = 1; 
    private float mouseZCoord; 
    private Vector3 originalPos; 
    public Vector3 movementVector; 
    

    public float speed; 

    float WPRadius = .5f; 

    void Update()
    {
        CheckWayPoints(); 
        
    }

    void CheckWayPoints()
    {

        


        //Object is on Waypoint
        if(Vector3.Distance(wayPoints[current].transform.position, transform.position) < WPRadius)
        {
            current++; 

            //Reached last checkpoint -> Add Finish Animation instead of loop etc. 
            if(current >= wayPoints.Length)
            {
                current = 0; 
            }
        }
        Move(); 
        
    }

    void Move()
    {
        //Moves towards current wayPoint; 
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[current].transform.position, Time.deltaTime * speed); 
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

    private Vector3 GetMovementVector()
    {
        //TO_DO
        //Transfrom GetMouseWorldPos to Vector/Area that object is allowed to move on; 


        return movementVector; 
    }

    private void OnMouseDrag()
    {
        //if(Input.mousePosition != objectToWaypoint)
            //return; 
        
        transform.position = GetMouseWorldPos(); 
    }
}
