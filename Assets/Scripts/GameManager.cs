using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{

    public KeyCode QuitKey = KeyCode.Escape; 
    public KeyCode RelaodKey = KeyCode.R; 


    void Update()
    {
        if(Input.GetKeyDown(QuitKey))
        {
            Debug.Log("Application Quit"); 
            Application.Quit(); 
        }

        if(Input.GetKeyDown(RelaodKey))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            
        }
    }
}
