using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    

    [Tooltip("Animators need activate/deactivate Trigger; Animator 00 Refers to clicked object;")]
    [Header("Animators")]
    [SerializeField] Animator animator;
    [SerializeField] Animator animator01;
    [SerializeField] Animator animator02;

    [Tooltip("Ref colliders will be enabled/disabled on activation;")]
    [Header("Colliders")]
    [SerializeField] Collider refCollider;
    [SerializeField] Collider refCollider01;

    [Header("Currently Activated")]
    public bool currentlyActivated = false;




    
    private void OnMouseDown()
    {
        
        //Animators
        if(animator != null)
        {
            if (currentlyActivated == false)
            {
                currentlyActivated = true; 

                
                animator.SetTrigger("activate");

            }
            else
            {
                currentlyActivated = false; 

                
                animator.SetTrigger("deactivate");

            }
        }
         

        if (animator01 != null)
            animator01.SetTrigger("activate");

        if (animator02 != null)
            animator02.SetTrigger("activate");



        //Ref Colliders
        if(refCollider != null)
            refCollider.enabled = true;
        if (refCollider01 != null)
            refCollider01.enabled = true;
    }

    

}
