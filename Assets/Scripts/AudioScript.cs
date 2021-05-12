using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioClip Test;
    static AudioSource audioSrc;

    void Start()
    {
        Test = Resources.Load<AudioClip>("test");

        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null) audioSrc = gameObject.AddComponent<AudioSource>();
    }
    // AudioScript.PlaySound("Test");


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "test":
                audioSrc.PlayOneShot(Test);
                break;

        }
    }
}
