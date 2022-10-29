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
    public override void grab(Transform holdPos)
    {
        base.grab(holdPos);
        this.transform.Rotate(new Vector3(-35f, 0, 0));
    }


}
