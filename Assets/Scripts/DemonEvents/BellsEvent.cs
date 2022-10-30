using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellsEvent : MonoBehaviour
{
    [SerializeField]public List<GameObject> code = new List<GameObject>();
    [SerializeField]GameObject []trueCode = new GameObject[3];
    [SerializeField]AudioClip []ac = new AudioClip[2];
    [SerializeField]AudioSource AudioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (code.Count >= 3)
        {
            bool correct = true;
            //print("Bell Code: "+code[0].name+" "+code[1].name+" "+code[2].name);
            for (int i = 0; i < 3; i++)
            {
                if (code[i] != trueCode[i])
                {
                    correct = false;
                    break;
                }
            }

            if(correct)
            {
                if (GameManager.Instance.demon == 1)
                {
                    AudioPlayer.PlayOneShot(ac[1]);
                    GameManager.Instance.CounterEvent();
                }
            }
            else
            {
                AudioPlayer.PlayOneShot(ac[0]);
                //print("Incorrect!");
            }
            code.Clear();
        }
    }
}
