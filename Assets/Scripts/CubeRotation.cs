using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public static CubeRotation instance; 

    public bool isDisabled = false; 

    [Header("Rotation Speed")]
    public float rotationSpeedX = 20;
    public float rotationSpeedY = 20;

    Vector2 currentMousePos; 
    Vector2 mousePosOnClick;

    float rotX; 
    float rotY; 

   

   
    void Awake()
    {
        //singleton
        if(instance == null )
            instance = this; 
        else
            Destroy(gameObject); 
    }

    void Update()
    {
        currentMousePos = Input.mousePosition; 

        //Debug.Log(Input.GetAxis("Mouse X")); 

        if(Input.GetMouseButtonDown(1))
        {
            mousePosOnClick = Input.mousePosition; 

        }
        if(Input.GetMouseButton(1))
        {
            //on Mouse Drag 
            onRightClick(); 
        }
       
       
    }



    void onRightClick()
    {   
        if(isDisabled)
            return; 

        //Calculates Absolute Difference between mosuePos on lick and currentMouse Pos
        float mouseDeltaY = Mathf.Abs(currentMousePos.y - mousePosOnClick.y); 
        float mouseDeltaX = Mathf.Abs(currentMousePos.x - mousePosOnClick.x); 

        //rotates in direction where mouseDelta is larger
        if(mouseDeltaX > mouseDeltaY)
        {
            rotX = Input.GetAxis("Mouse X") * rotationSpeedX;
            transform.Rotate(0,-rotX,0,Space.World);
        }
        else 
        {
            rotY = Input.GetAxis("Mouse Y") * rotationSpeedY;
            transform.Rotate(rotY,0,0,Space.World);

        }

        
        

    }
  

}
