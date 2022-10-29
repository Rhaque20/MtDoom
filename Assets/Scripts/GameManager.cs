using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //struct sector
    //{
    //    public bool hasYokai;
    //}



    public static GameManager Instance;
    [SerializeField]
    int ritualGoal;
    [SerializeField]
    float reactionTime;
    float fluteCounter,bellCounter;
    int ritualProgress;// Current bar progress
    float demonDistance;// Time until demon arrives to kill player
    [SerializeField]
    float timer=360;// Time until day ends
    [SerializeField]
    TextMeshProUGUI timerText;

    //singleton game manager
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer system
        timer -= Time.deltaTime;
       // print(timer);
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        timerText.text = minutes + ":" + seconds;

        if (timer <= 0)
        {
            print("game should end");
        }
        if (fluteCounter > 0)
        {
            fluteCounter -= Time.deltaTime;
        }

    }

    void demonEvent()
    {
        fluteCounter = reactionTime;
    }

    public void Flute()
    {
        print("Flute action");
    }

   

}
