using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class MazeAgentController : MonoBehaviour
{
    public NavMeshAgent agent; 

    private Vector3 destination; 

    //TO DO 
    //
    //On Mouse Click
    // -> NavMeshAgent anschalten
    //
    //OnMouseDrag
    //SetDestination(Input.mouseposition)
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
        
    }

    void Update()
    {
        
    }

    
    void OnMouseDown()
    {
        Debug.Log("Clicked"); 

    }
    
    
    void OnMouseUp()
    {
        agent.enabled = false;
    }

 
    void OnMouseDrag()
    {
        agent.enabled = true; 

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hit; 

        if(Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point); 
        }
        
    }
}
