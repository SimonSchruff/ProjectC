using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float rotationSpeedX = 20;
    public float rotationSpeedY = 20;

    [SerializeField] private LayerMask clickableLayer;

    private List<GameObject> selectedObjects = new List<GameObject>(); 


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

        //rotation auf beiden Achsen für Prototyp erstmal auskommentiert
        float rotX = Input.GetAxis("Mouse X") * rotationSpeedX * Mathf.Deg2Rad;
        //float rotY = - Input.GetAxis("Mouse Y") * rotationSpeedY * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        //transform.RotateAround(Vector3.right, rotY);

    }

    void onLeftClick()
    {

        //Casts Ray from Cam pos to Mouse Pos; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, clickableLayer))
        {
            if (hit.collider.GetComponent<ClickableObject>() != null)
            {
                ClickableObject clickedObject = hit.collider.GetComponent<ClickableObject>();
                selectedObjects.Add(hit.collider.gameObject);

                if(selectedObjects.Count > 0)
                {
                    foreach (GameObject obj in selectedObjects)
                    {
                        obj.GetComponent<ClickableObject>().currentlySelected = false;
                        obj.GetComponent<ClickableObject>().OnClicked(); 
                    }

                    selectedObjects.Clear(); 
                }

                selectedObjects.Add(hit.collider.gameObject);
                clickedObject.currentlySelected = true;
                clickedObject.OnClicked(); 


                 

            }


        }
        else
            return; 


    }
}
