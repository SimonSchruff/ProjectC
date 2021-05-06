using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float rotationSpeedX = 20;
    public float rotationSpeedY = 20;

   

    // TO - DO:
    // Fix Rotation
    //


    void Update()
    {

        /////// INPUT HANDLER ///////
        
        if(Input.GetMouseButton(1))
        {
            onRightClick(); 
        }
        else if(Input.GetMouseButtonDown(0))
        {
            onLeftClick(); 
        }
  
    }



    void onRightClick()
    {

        //Rotates Cube Parent

        float rotX = Input.GetAxis("Mouse X") * rotationSpeedX;
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeedY;

        transform.Rotate(rotY,-rotX,0,Space.World);
        

    }

    void onLeftClick()
    {

        //Left Clicks are handled in each object individually 
    }

  

}
