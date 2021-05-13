using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reihenfolgeButtonCheck : MonoBehaviour
{
    public OneWayButtonTrigger[] buttons = new OneWayButtonTrigger[2]; 

    public GameObject[] lamps; 

    

    public bool buttonOnePressed; 
    public bool buttonTwoPressed; 

    public bool isSolved; 


    
    void Update()
    {
        //IS button 0 active or not
        if(buttons[0].currentlyActivated)
            buttonOnePressed = true; 
        else
            buttonOnePressed = false; 

        if(buttonOnePressed)
        {
            // if 0 is active look if 1 is active
            if(buttons[1].currentlyActivated)
            {
                //time since 0 button is pressed has to be larger then time since 1 button was pressed
                if(buttons[0].timeSincePressed > buttons[1].timeSincePressed )
                {
                    buttonTwoPressed = true; 
                }
                else    
                    buttonTwoPressed = false; 
            }
            else
                buttonTwoPressed = false; 
        }


        //Check if both are pressed
        if(buttonOnePressed && buttonTwoPressed)
        {
            //is button 2 active
            if(buttons[2].currentlyActivated)
            {
                //time since 1 button is pressed has to be larger then time since 2 button was pressed
                if(buttons[1].timeSincePressed > buttons[2].timeSincePressed )
                {
                    //puzzle solved
                    isSolved = true; 
                }
                
            }
        }

        

        if(isSolved)
            lampCycle();  

       

        


    }
        
    void lampCycle()
    {
        lamps[0].SetActive(true); 
        lamps[1].SetActive(false); 
        lamps[2].SetActive(false); 

        StartCoroutine(waitForTwoSeconds()); 

        lamps[0].SetActive(false); 
        lamps[1].SetActive(false); 
        lamps[2].SetActive(true);

        StartCoroutine(waitForTwoSeconds()); 

        lamps[0].SetActive(false); 
        lamps[1].SetActive(true); 
        lamps[2].SetActive(false);

        StartCoroutine(waitForTwoSeconds()); 
    }

    IEnumerator waitForTwoSeconds()
    {
        yield return new WaitForSeconds(2); 
    }
    



}
