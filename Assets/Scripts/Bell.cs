using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : Interactable
{
    AudioSource audioSource;

    
    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();        
    }

    public override void Interaction()
    {
        base.Interaction();
        print("bell is working");
        audioSource.Play();
    }
}
