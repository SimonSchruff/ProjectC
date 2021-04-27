using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour
{
    public float rotationSpeed = 20;


    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            onRightClick(); 
        }
    }



    void onRightClick()
    {
        transform.Rotate(new Vector3(- Input.GetAxis("Mouse Y"), - Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);

    }
}
