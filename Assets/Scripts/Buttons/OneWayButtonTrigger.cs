using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayButtonTrigger : MonoBehaviour
{
    
     
    
    [Header("Animators")]

    private Animator ownAnimator;

    //Only external Animators need to be put into Inspector
    public Animator[] otherAnimators; 
    

    [Header("Colliders")]


    public Collider[] colliders; 
    

    [Header("Timer")]
    public bool currentlyActivated = false;
    public float timeBeforeInactive;
    private float currentTime; 

    public float timeSincePressed; 

    [Header("Level02")]
    public GameObject lamp; 
    public GameObject[] lights; 


    [Header("Level04")]
    public GameObject turnObject ;
    public int turnAmount;


    public float lv4Timer; 
    public bool lv4OnClick; 


    
    void Start()
    {
        if(GetComponent<Animator>() != null)
        {
            ownAnimator = GetComponent<Animator>(); 
        }
    }

    
    void Update()    
    {
        timeSincePressed += Time.time; 

        //Timer; Disabled on 0
        if(currentTime > 0)
            currentTime -= Time.deltaTime; 
        else    
            currentTime = 0; 

        
        if(currentTime == 0)
            currentlyActivated = false; 



        if(lv4Timer > 0 && lv4OnClick == true)
        {
            lv4Timer -= Time.deltaTime; 
        }    
        
    }


    
    private void OnMouseDown()
    {
        //Sets own Animator and currentlyActivated
        timeSincePressed = 0; 
        currentlyActivated = true; 
        currentTime = timeBeforeInactive; 

        //After certain timer deactivate? 
        if(ownAnimator != null)
            ownAnimator.SetTrigger("activate");



        //Level04 Zahnrad
        if(CompareTag("ButtonLv4"))
        {
            Level04Zahnrad(); 
        }
        else if(CompareTag("ButtonLv2"))
        {
            Level02Zahnrad(); 
        }

            
           
        SetExternalAnimators(); 
        SetExternalColliders(); 
       
        
        
       
    }

    void SetExternalAnimators()
    {
        //Sets Trigger for external Animators
        //All Animators NEED Trigger "activate" AND "deactivate" even if unused 
        

        foreach(Animator a in otherAnimators)
        {
            if (currentlyActivated == true)
            {
                a.SetTrigger("activate");
            }
            else
            {
               
                a.SetTrigger("deactivate");
            }
        }
    }

    void SetExternalColliders()
    {
        //Enables or Disabled referenced Colliders
        foreach(Collider c in colliders)
        {
            if(c.enabled == false)
            {
                c.enabled = true; 
            }
            else
            {
                c.enabled = false; 
            }
        }    
    }

   

    void Level04Zahnrad()
    {
        StartCoroutine(Countdown()); 

        //turnObject.transform.Rotate(new Vector3(0,turnAmount,0), Space.Self); 
           

    }

    void Level02Zahnrad()
    {


        foreach(Animator a in otherAnimators)
        {
            a.SetTrigger("activate"); 
        }

        foreach(GameObject go in lights)
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

        lamp.SetActive(true); 
    }
       
    private IEnumerator Countdown()
    {
        //Debug.Log("countdown"); 
        
        yield return new WaitForSeconds(1); 

        turnObject.transform.Rotate(new Vector3(0,turnAmount,0), Space.Self);
        
    }
    

}
