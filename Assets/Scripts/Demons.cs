using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demons : MonoBehaviour
{
    int demon = 0;
    public enum Difficulty{Easy,Normal,Hard};
    Difficulty d = Difficulty.Easy;
    float difficultymod = 1.0f;

    public float dmod
    {
        get{return difficultymod;}
    }// Return current difficulty

    public int activeDemon
    {
        get{return demon;}
    }

    public int CallDemon()// Return randomly called demon
    {
        demon = Random.Range(1,2);
        return demon;
    }

    public void RaiseDifficulty()
    {
        switch(d)
        {
            case Difficulty.Easy:
                d = Difficulty.Normal;
                difficultymod = 0.75f;
                break;
            default:
                d = Difficulty.Hard;
                difficultymod = 0.5f;
                break;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
