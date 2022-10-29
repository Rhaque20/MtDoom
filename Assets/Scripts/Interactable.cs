using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    bool Holdable, LongInteraction;
    public bool holdable { get { return Holdable; } }
    public bool longInteraction { get { return LongInteraction; } }

    

    Vector3 originalPosition;
    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        if (holdable)
        {
            originalPosition = this.transform.position;
            originalRotation = this.transform.rotation;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //interactions
     public virtual void Interaction()
    {
        print("interacted");

    }
    public virtual void HeldInteraction()
    {
        print("interacted");

    }
    //this allows you to grab the item
    public virtual void grab(Transform holdPos)
    {
        this.transform.position = holdPos.position;
        this.transform.rotation = holdPos.rotation;
        this.transform.SetParent(holdPos);
        this.GetComponent<Collider>().enabled=false;
        print("interacted");

    }
    //this returns the object to its start position and reeanables colliders
    public virtual void returnObject()
    {
        this.transform.SetParent(null);
        this.transform.position = originalPosition;
        this.transform.rotation = originalRotation;
        this.GetComponent<Collider>().enabled = true;
    }
}
