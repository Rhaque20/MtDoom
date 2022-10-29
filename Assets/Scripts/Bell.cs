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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void interaction()
    {
        base.interaction();
        print("bell is working");
        audio.Play();
    }
}
