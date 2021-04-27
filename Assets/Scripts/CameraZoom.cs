using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public float zoomSpeed;

    public float fovMin;
    public float fovMax;

    private Camera cam; 

    void Start()
    {
        cam = GetComponent<Camera>(); 
    }

    void Update()
    {
   
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            cam.fieldOfView += zoomSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            cam.fieldOfView -= zoomSpeed;
        }
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, fovMin, fovMax);
        

        //End Update
    }


}
