using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSound : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip candleSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        audiosource.clip = candleSound;
        audiosource.Play();
    }
}
