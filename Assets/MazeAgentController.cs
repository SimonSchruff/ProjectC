using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class MazeAgentController : MonoBehaviour
{
    public NavMeshAgent agent; 

    public Vector3 destination; 
    private Vector3 targetRadius; 

    private CubeRotation cubeRotation;
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>(); 
        cubeRotation = FindObjectOfType<CubeRotation>(); 
        
    }
    void OnMouseDownUp()
    {
        cubeRotation.isDisabled = false; 
        agent.enabled = false; 

    }
    
    
    
 
    void OnMouseDrag()
    {


        agent.enabled = true; 
        cubeRotation.isDisabled = true; 

        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hit; 

        if(Physics.Raycast(ray, out hit))
        {
            //Debug.Log("MouseDrag"); 

            agent.SetDestination(hit.point); 
        }
        
       
    }
}
