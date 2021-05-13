using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public int targetPumpValue; 
    public int currentPumpValue; 

    private bool reachedTop; 

    public int topBounds; 


    [Header("Object Refs")]
    public GameObject parentObject;
    public Animator harmonika; 

    public Animator zeiger; 

    public GameObject lampe; 
    
    

    [Header("Bounds")]
    Vector3 originalPos;

    [Tooltip("Max/Min Bounds according to resulting movementVector.y of mouse position")]
    private Vector3 movementVector;

    private float mouseZCoord;

    public float maxBounds;
    public float minBounds; 



    CubeRotation cubeRotation; 




    private void Start()
    {
        reachedTop = false; 
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
        //disabled rotation of parent cube
        cubeRotation.isDisabled = true; 

        //Counts pumps
        CountPumps(); 

        harmonika.SetInteger("active",currentPumpValue); 
       
        //Clamp Y MovementVector to max/min Bounds; 
        Vector3 moveVectorClamped = new Vector3(GetMovementVector().x,Mathf.Clamp(GetMovementVector().y,originalPos.y - minBounds, originalPos.y + maxBounds),GetMovementVector().z);  
        parentObject.transform.position = moveVectorClamped; 
    
    }

    private void CountPumps()
    {
        //if bot reached; count++
        //Until top is reached not possible to count 

        

        if(parentObject.transform.position.y < -35 && reachedTop == true)
        {
            currentPumpValue++;
            reachedTop = false;  
        }
        else if(parentObject.transform.position.y > -35)
        {
            reachedTop = true; 
        }
        else if(currentPumpValue >= targetPumpValue)
        {
            zeiger.SetTrigger("full"); 
            lampe.SetActive(true); 
        }
    }

    private void OnMouseUp()
    {
        cubeRotation.isDisabled = false;
        currentPumpValue = 0; 

        harmonika.SetInteger("active",currentPumpValue); 
         
        parentObject.transform.position = originalPos; 
    }
}
