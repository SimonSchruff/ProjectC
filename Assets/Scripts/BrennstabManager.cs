using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrennstabManager : MonoBehaviour
{
    public ButtonTrigger Switch00; 
    public ButtonTrigger Switch01; 
    public ButtonTrigger Switch02; 
    public ButtonTrigger Switch03; 

    bool isSolved; 




    [Header("GameObjects")]
    public GameObject[] gameObjects; 

    public Animator animator; 

    void Update()
    {
        if(isSolved == false && Switch00.currentlyActivated == false && Switch01.currentlyActivated == true && Switch02.currentlyActivated == true && Switch03.currentlyActivated == false)
        {
            isSolved = true; 
            //Debug.Log("Brennstab Puzzle Solved!"); 
            //Play Animation LIT
            animator.SetTrigger("activate"); 

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
}
