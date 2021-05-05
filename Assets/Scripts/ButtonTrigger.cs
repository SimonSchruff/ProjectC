using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [Header("Animators")]
    [SerializeField] Animator animator;
    [SerializeField] Animator animator01;
    [SerializeField] Animator animator02;

    [Header("Colliders")]
    [SerializeField] Collider refCollider;


    public bool currentlyActivated = false;

    
    private void OnMouseDown()
    {
        

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

        if(refCollider != null)
            refCollider.enabled = true; 
    }
}
