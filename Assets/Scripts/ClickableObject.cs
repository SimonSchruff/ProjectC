using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private MeshRenderer meshR;
    [SerializeField] Material redMat;
    [SerializeField] Material whiteMat; 

    public bool currentlySelected;

    Animator animator; 

    [Header("PickUp")]
    Vector3 originalPos;
    private bool isPickUp = false; 
    private Vector3 mouseOffset;
    private float mouseZCoord; 

    // ------ NOTES --------
    //
    // Different Interactables with overrides of class?


    private void Start()
    {
        meshR = GetComponent<MeshRenderer>();
        animator = GetComponent<Animator>();
    }

    //Gets called from player Input
    public void OnClicked()
    {
        
        if(currentlySelected == false)
        {
            if(whiteMat != null)
                meshR.material = whiteMat;

            
        }
        else
        {
            if(redMat != null)
                meshR.material = redMat;


            if (CompareTag("Button"))
            {
                Debug.Log("This is a Button");
                //Play Anim etc.
                animator.SetTrigger("activate");
            }
            else if (CompareTag("PickUp"))
            {
                isPickUp = true;
                //Saves original pos of object for reset; 
                originalPos = transform.position;

            }
        }
    }


    private void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //Store offset = GameObject world pos - mouse world pos
        mouseOffset = gameObject.transform.position - GetMouseWorldPos(); 
    }

    private Vector3 GetMouseWorldPos()
    {
        //x,y coordinates 
        Vector3 mousePoint = Input.mousePosition;
        

        //z coordinate of gameobject on screen
        mousePoint.z = mouseZCoord; 

        return Camera.main.ScreenToWorldPoint(mousePoint); 

    }

    private void OnMouseDrag()
    {
        if (!isPickUp)
            return;

        transform.position = GetMouseWorldPos() + mouseOffset; 
    }
    private void OnMouseExit()
    {
        if (!isPickUp)
            return;

        transform.position = originalPos; 
    }
}
