using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flute : Interactable
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] clips;
    float holdTime = 0f;
    [SerializeField]float shortNoteWindow = 0.3f;
    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public override void HeldInteraction()
    {
        print("Playing the flute!");
        holdTime += Time.deltaTime;
    }

    public override void Interaction()
    {
        base.Interaction();
        GameManager.Instance.Flute();
       // audioSource.time = 0;
       // audioSource.Stop();
        audioSource.clip = clips[(int)Random.Range(0, clips.Length)];
        audioSource.Play();
    }
    public override void releasedInteraction()
    {
        base.releasedInteraction();
        //if (audioSource.time < audioSource.clip.length * .5f)
        //{
        //    audioSource.time = audioSource.clip.length * .5f;
        //}
        if (holdTime <= shortNoteWindow)
            print("Short note!");
        else
            print("Long note!");
        holdTime = 0f;
        //print("Release!");
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
