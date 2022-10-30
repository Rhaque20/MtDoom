using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : Interactable
{
    AudioSource audioSource;
    BellsEvent be;
    
    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>(); 
        be = gameObject.GetComponentInParent<BellsEvent>();       
    }

    public override void Interaction()
    {
        base.Interaction();
        print("bell is working" +this.name);
        audioSource.Play();
        be.code.Add(this.gameObject);
    }
}
