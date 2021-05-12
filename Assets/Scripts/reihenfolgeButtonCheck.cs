using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reihenfolgeButtonCheck : MonoBehaviour
{
    public OneWayButtonTrigger[] buttons = new OneWayButtonTrigger[2]; 

    private bool buttonOnePressed; 
    private bool buttonTwoPressed; 


    void Start()
    {
        
    }

    void Update()
    {
        //Check for Button One
        if(buttons[0].currentlyActivated == true)
        {
            buttonOnePressed = true; 
        }
        else if(buttons[0].currentlyActivated == false)
        {
            buttonOnePressed = false; 
        }

        //Check for Button Two
        if(buttons[1].currentlyActivated == true && buttonOnePressed == true)
        {
            buttonTwoPressed = true; 
        }
        else if(buttons[1].currentlyActivated == false)
        {
            buttonTwoPressed = false; 
        }

        //CheckForButtonThree
        if(buttons[2].currentlyActivated == true && buttonOnePressed == true && buttonTwoPressed == true)
        {
            Debug.Log("CorrectOrder"); 
        }

    }



}
