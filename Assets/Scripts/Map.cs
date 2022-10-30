using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Interactable
{

    public override void grab(Transform holdPos)
    {
        base.grab(holdPos);
        this.transform.Translate(0, 0, -0.5f);
        this.transform.Rotate(new Vector3(45f, 0, 0));
        
    }
}
