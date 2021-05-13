using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohrSchalterCheck : MonoBehaviour
{
    public ButtonTrigger[] buttons; 
    private bool isSolved; 

    public Animator waterA ;

   
    

    // Update is called once per frame
    void Update()
    {
        checkAllPipes(); 

        if(isSolved)
        {
            waterA.SetTrigger("activate"); 
        }
    }

    void checkAllPipes()
    {
        if(buttons[0].currentlyActivated == true && buttons[1].currentlyActivated == true)
        {
            isSolved = true; 
        }
    }
}
