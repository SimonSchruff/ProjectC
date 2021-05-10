using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    

    
    [Header("Animators")]

    private Animator ownAnimator;

    [Tooltip("Only External Animators need to be referenced!")] 
    public Animator[] otherAnimators; 
    

    [Tooltip("Ref colliders will be enabled/disabled on activation;")]
    [Header("Colliders")]
    [SerializeField] Collider refCollider;
    [SerializeField] Collider refCollider01;

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
        
            
        //Ref Colliders
        if(refCollider != null)
            refCollider.enabled = true;
        if (refCollider01 != null)
            refCollider01.enabled = true;
    }

    

}
