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
    float reactionTime;// Time until demon arrives to kill player
    float fluteCounter,bellCounter;
    int ritualProgress;// Current bar progress
    //float demonDistance = 10f;// Grace period until next demon attack
    [SerializeField]
    float timer=360;// Time until day ends
    [SerializeField]
    TextMeshProUGUI timerText;
    Coroutine demonDistance;
    Demons d;


    private IEnumerator Timers(int stage,float countdown)// Will run a two stage timer
    {
        yield return new WaitForSeconds(countdown);

        switch(stage)
        {
            // This is the cooldown for demon attack.
            case 0:
                int demon;
                demon = d.CallDemon();// Will check which demon to use and activate specific object
                /**
                    run if/switch statement of triggering an object event
                **/
                // Start the reaction timer, will use timer modifier from from demon script
                demonDistance = StartCoroutine(Timers(1,10f * d.dmod));
                break;
            case 1:
                // Trigger gameover here
                print("GAME OVER!");
                demonDistance = null;
                break;

        }
    }

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

        if (demonDistance == null)// Check if no cooldown is active.
        {
            demonDistance = StartCoroutine(Timers(0,10f));
        }

    }

    void fluteEvent()
    {
        fluteCounter = reactionTime;
    }

    public void Flute()
    {
        print("Flute action");
    }

   

}
