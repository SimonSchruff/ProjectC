using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float rotationSpeedX = 20;
    public float rotationSpeedY = 20;


    void Update()
    {

        /////// INPUT HANDLER ///////
        
        if(Input.GetMouseButton(1))
        {
            onRightClick(); 
        }
        else if(Input.GetMouseButton(0))
        {
            onLeftClick(); 
        }
    }



    void onRightClick()
    {

        //Rotates Cube Parent


        float rotX = Input.GetAxis("Mouse X") * rotationSpeedX * Mathf.Deg2Rad;
        float rotY = - Input.GetAxis("Mouse Y") * rotationSpeedY * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        transform.RotateAround(Vector3.right, rotY);

    }

    void onLeftClick()
    {

        //Casts Ray from Cam pos to Mouse Pos and checks for Interactable(Tag)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Interactable"))
            {
                Debug.Log("Interactable Clicked");
            }
            else
            {
                Debug.Log("Clicked Object is not an Interactalbe"); 
            }
        }
        else
            return; 


    }
}
