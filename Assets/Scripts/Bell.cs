using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : Interactable
{
    AudioSource audio;
    private void Awake()
    {
        audio = this.GetComponent<AudioSource>();        
    }

    public override void Interaction()
    {
        base.Interaction();
        print("bell is working");
        audio.Play();
    }
}
