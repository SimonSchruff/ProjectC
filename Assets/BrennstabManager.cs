using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrennstabManager : MonoBehaviour
{
    public ButtonTrigger Switch00; 
    public ButtonTrigger Switch01; 
    public ButtonTrigger Switch02; 
    public ButtonTrigger Switch03; 

    void Update()
    {
        if(Switch00.currentlyActivated == false && Switch01.currentlyActivated == true && Switch02.currentlyActivated == true && Switch03.currentlyActivated == false)
        {
            Debug.Log("Brennstab Puzzle Solved!"); 
        }
    }
}
