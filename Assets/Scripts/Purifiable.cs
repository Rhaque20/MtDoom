using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purifiable : Interactable
{
    [SerializeField]
    float interactionLength;
    float counter;
    bool canBeInteracted=true;
    private void Awake()
    {
        counter = interactionLength;
    }
    public override void Interaction()
    {
        base.Interaction();
        counter = interactionLength;
    }
    public override void HeldInteraction()
    {
        base.HeldInteraction();

        if (canBeInteracted)
        {
            if (longInteraction)
            {
                counter -= Time.deltaTime;
                print(counter);
                
            }
            if (counter <= 0)
            {
                print("send interaction");
                counter = interactionLength;
                canBeInteracted = false;
            }
        }
        
    }
}
