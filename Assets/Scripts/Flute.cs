using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flute : Interactable
{
   public override void interaction()
    {
        base.interaction();
        GameManager.Instance.Flute();
    }

    
}
