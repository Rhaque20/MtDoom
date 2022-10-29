using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flute : Interactable
{
   public override void Interaction()
    {
        base.Interaction();
        GameManager.Instance.Flute();
    }
    public override void grab(Transform holdPos)
    {
        base.grab(holdPos);
        this.transform.Rotate(new Vector3(-35f, 0, 0));
    }


}
