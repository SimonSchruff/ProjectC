using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    

    
    [Header("Animators")]

    private Animator ownAnimator;

    //Only external Animators need to be put into Inspector
    public Animator[] otherAnimators; 
    

    [Header("Colliders")]


    public Collider[] colliders; 
    

    [Header("GameObjects")]
    public GameObject[] gameObjects; 
    

    [Header("Currently Activated")]
    public bool currentlyActivated = false;


    
    void Start()
    {
        if(GetComponent<Animator>() != null)
        {
            ownAnimator = GetComponent<Animator>(); 
        }
    }


    
    private void OnMouseDown()
    {
        //Sets own Animator and currentlyActivated
        if (currentlyActivated == false)
            {
                currentlyActivated = true; 

                ownAnimator.SetTrigger("activate");
            }
            else
            {
                currentlyActivated = false; 

                ownAnimator.SetTrigger("deactivate");
            } 


        //Sets Trigger for external Animators
        //
        ///////////     All Animators NEED Trigger "activate" AND "deactivate" even if unused   //////////
        //
        foreach(Animator a in otherAnimators)
        {
            if (currentlyActivated == true)
            {
                a.SetTrigger("activate");
            }
            else
            {
               
                a.SetTrigger("deactivate");
            }
        }
        
        //Enables or Disabled referenced Colliders
        foreach(Collider c in colliders)
        {
            if(c.enabled == false)
            {
                c.enabled = true; 
            }
            else
            {
                c.enabled = false; 
            }
        }   


        foreach(GameObject go in gameObjects)
        {
            if(go.activeInHierarchy == false)
            {
                go.SetActive(true);  
            }
            else
            {
                go.SetActive(false); 
            }
        }     
       
    }

    

}
