using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flute : Interactable
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] clips;
    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public override void Interaction()
    {
        base.Interaction();
        GameManager.Instance.Flute();
        
        audioSource.PlayOneShot(clips[(int)Random.Range(0,clips.Length)]);
    }
    public override void releasedInteraction()
    {
        base.releasedInteraction();
        audioSource.Stop();
    }
    public override void grab(Transform holdPos)
    {
        base.grab(holdPos);
        this.transform.Rotate(new Vector3(-35f, 0, 0));
    }
    public override void returnObject()
    {
        base.returnObject();
        audioSource.Stop();
    }


}
