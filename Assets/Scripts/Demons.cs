using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demons : MonoBehaviour
{
    int demon = 0;
    enum Difficulty{Easy,Normal,Hard};
    Difficulty d = Difficulty.Easy;

    public Difficulty difficulty
    {
        get{return d;}
    }// Return current difficulty

    public int CallDemon()// Return randomly called demon
    {
        demon = Random.Range(1,3);
        return demon;
    }

    public void RaiseDifficulty()
    {
        switch(d)
        {
            case Difficulty.Easy:
                d = Difficulty.Normal;
                break;
            default:
                d = Difficulty.Hard;
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
