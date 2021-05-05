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


    private void OnMouseDown()
    {
        if(animator != null)
            animator.SetTrigger("activate");

        if (animator01 != null)
            animator01.SetTrigger("activate");

        if (animator02 != null)
            animator02.SetTrigger("activate");

        if(refCollider != null)
            refCollider.enabled = true; 
    }
}
