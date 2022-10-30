using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : Interactable
{
    AudioSource audioSource;
    DemonEvent de;
    
    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>(); 
        de = gameObject.GetComponentInParent<DemonEvent>();       
    }

    public override void Interaction()
    {
        base.Interaction();
        print("bell is working" +this.name);
        audioSource.Play();
        de.code.Add(this.gameObject);
    }
}
