using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zahlenrad : MonoBehaviour
{
    
    public GameObject ZahlenradObject; 
    
    [Header("Animators")]

    private Animator ownAnimator;

    //Only external Animators need to be put into Inspector
    public Animator[] otherAnimators; 
    

    [Header("Colliders")]


    public Collider[] colliders; 
    

    [Header("Timer")]
    public bool currentlyActivated = false;
    public float timeBeforeInactive;
    private float currentTime; 


    
    void Start()
    {
        if(GetComponent<Animator>() != null)
        {
            ownAnimator = GetComponent<Animator>(); 
        }
    }

    
    void Update()    
    {
        //Timer; Disabled on 0
        if(currentTime > 0)
            currentTime -= Time.deltaTime; 
        else    
            currentTime = 0; 

        
        if(currentTime == 0)
            currentlyActivated = false; 
        
    }


    
    private void OnMouseDown()
    {
        //Sets own Animator and currentlyActivated
        
        currentlyActivated = true; 
        currentTime = timeBeforeInactive; 

        //After certain timer deactivate? 
        if(ownAnimator != null)
            ownAnimator.SetTrigger("activate");

        transform.Rotate(new Vector3(0, 30 ,0), Space.Self); 
        ZahlenradObject.transform.Rotate(new Vector3(0, 120,0), Space.Self); 
            
           
        SetExternalAnimators(); 
        SetExternalColliders(); 
       
        
        
       
    }

    void SetExternalAnimators()
    {
        //Sets Trigger for external Animators
        //All Animators NEED Trigger "activate" AND "deactivate" even if unused 
        

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
    }

    void SetExternalColliders()
    {
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
    }

    

}
