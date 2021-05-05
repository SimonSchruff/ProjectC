using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float rotationSpeedX = 20;
    public float rotationSpeedY = 20;

    [SerializeField] private LayerMask clickableLayer;

    private List<GameObject> selectedObjects = new List<GameObject>();


    [Header("Key Bindings")]
    public KeyCode deselectKey = KeyCode.Escape; 



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
        else if(Input.GetKeyDown(deselectKey))
        {
            Deselect(); 
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

        //Casts Ray from Cam pos to Mouse Pos; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, clickableLayer))
        {

            
                /////// BUTTON OBJECTS ///////////
            if (hit.collider.GetComponent<ButtonScript>() != null)
            {
                ButtonScript buttonObject = hit.collider.GetComponent<ButtonScript>();

                
                if (buttonObject.currentlySelected == false)
                {

                    // handles deselection of all other objects;
                    if (selectedObjects.Count > 0)
                    {
                        foreach (GameObject obj in selectedObjects)
                        {
                            obj.GetComponent<ButtonScript>().currentlySelected = false;
                            obj.GetComponent<ButtonScript>().OnClicked();
                        }

                        selectedObjects.Clear();

                    }


                    selectedObjects.Add(hit.collider.gameObject);
                    buttonObject.currentlySelected = true;
                    buttonObject.OnClicked();

                }
                else
                {
                    foreach (GameObject obj in selectedObjects)
                    {
                        obj.GetComponent<ButtonScript>().currentlySelected = false;
                        obj.GetComponent<ButtonScript>().OnClicked();
                    }

                    selectedObjects.Clear();
                }
                
            }
                    
                

        }


        //End left Click
    }

    void Deselect()
    {
        foreach(GameObject obj in selectedObjects)
        {
            obj.GetComponent<ClickableObject>().currentlySelected = false;
            obj.GetComponent<ClickableObject>().OnClicked();
        }

        selectedObjects.Clear();
    }

}
