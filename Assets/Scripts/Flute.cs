using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flute : Interactable
{
   public override void interaction()
    {
        GameManager.Instance.Flute();
    } 
}
