using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float rotationSpeed = 20;


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
        transform.Rotate(new Vector3(- Input.GetAxis("Mouse Y"), - Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);

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
