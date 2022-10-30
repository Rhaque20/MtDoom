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
    [SerializeField]bool []TrueCode = new bool[5];// True = Short, False = Long
    List<bool> insertCode = new List<bool>();

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
        insertCode.Add(holdTime <= shortNoteWindow);// Adds in result of bool statement
        /**
        if (holdTime <= shortNoteWindow)
            print("Short note!");
        else
            print("Long note!");
        **/
        holdTime = 0f;
        //print("Release!");
        audioSource.Stop();
        if (insertCode.Count >= 5)
        {
            bool correct = true;
            for (int i = 0; i < 5; i++)
            {
                correct = (insertCode[i] == TrueCode[i]);
                if (!correct)
                    break;
            }
            insertCode.Clear();
            if (correct && GameManager.Instance.demon == 2)
                GameManager.Instance.CounterEvent();
            else
                print("Incorrect Tune!");
        }
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
