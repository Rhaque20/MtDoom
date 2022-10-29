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

    public override void interaction()
    {
        base.interaction();
        print("bell is working");
        audio.Play();
    }
}
