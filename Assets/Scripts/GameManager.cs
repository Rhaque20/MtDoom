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


    bool onAttack = false;
    public bool gameStart = false, victory = false;
    public static GameManager Instance;
    [SerializeField]
    int ritualGoal;
    [SerializeField]
    float reactionTime;// Time until demon arrives to kill player
    float fluteCounter,bellCounter;
    int ritualProgress;// Current bar progress
    //float demonDistance = 10f;// Grace period until next demon attack
    [SerializeField]
    float timer=180f;// Time until day ends
    [SerializeField]
    TextMeshProUGUI timerText;
    Coroutine demonDistance;
    [SerializeField]Demons d;
    [SerializeField]GameObject [] demonSignals;
    public int demon = -1;
    [SerializeField]AudioSource AudioJungle;
    [SerializeField]AudioClip []ac = new AudioClip[3];
    GameObject demonJumpscare;
    player p;
    [SerializeField]
    LayerMask floorLayer;

    bool []isWin = new bool[2];

    private IEnumerator Timers(int stage,float countdown)// Will run a two stage timer
    {
        yield return new WaitForSeconds(countdown);

        switch(stage)
        {
            // This is the cooldown for demon attack.
            case 0:
                
                demon = d.CallDemon();// Will check which demon to use and activate specific object
                /**
                    play soundeffect of specified index
                **/
                // Start the reaction timer, will use timer modifier from from demon script
                //AudioJungle.PlayOneShot(ac[3]);
                AudioJungle.PlayOneShot(ac[demon]);
                if (demon == 0)
                    print("A strong demonic energy is approaching!");
                else if (demon == 1)
                {
                    print("A demonic flame is approaching, ring the bells!");
                    demonSignals[0].SetActive(true);
                }else
                if (demon == 2)
                    print("A demon wind is approaching, play the flute!");
                onAttack = true;
                demonDistance = StartCoroutine(Timers(1,10f * d.dmod));
                break;
            case 1:
                // Trigger gameover here
                print("GAME OVER!");
                onAttack = false;
                demon = -1;
                JumpScare();
                demonDistance = null;
                p.enabled = false;
                //demonJumpscare.transform.rotation = new Quaternion(demonJumpscare.transform.rotation.x, targetRotation.y, demonJumpscare.transform.rotation.z, demonJumpscare.transform.rotation.w);
                break;

        }
    }

    void JumpScare()
    {
        RaycastHit hit;

        //demonJumpscare.transform.position = p.transform.position - demonJumpscare.transform.position;
        AudioJungle.PlayOneShot(ac[3]);
        demonJumpscare.transform.position = p.transform.position + p.transform.forward;
        if (Physics.Raycast(demonJumpscare.transform.position, Vector3.down, out hit, 1.5f, floorLayer))
        {
            demonJumpscare.transform.position = hit.point + Vector3.up * 1.398f;
        }
        Vector3 direction = p.transform.position - demonJumpscare.transform.position;
        Quaternion targetRotation= Quaternion.LookRotation(direction, Vector3.up);
        demonJumpscare.transform.localEulerAngles = new Vector3(demonJumpscare.transform.localEulerAngles.x, targetRotation.eulerAngles.y, demonJumpscare.transform.localEulerAngles.z);
        Camera.main.transform.LookAt(demonJumpscare.transform.position);
    }

    public void PurificationComplete()
    {
        isWin[1] = true;
    }

    public void CounterEvent()
    {
        if (onAttack)// If an attack event is in progress cancel it
        {
            print("The demon has disappeared....for now...");
            demonSignals[0].SetActive(false);
            StopCoroutine(demonDistance);
            demonDistance = null;
            onAttack = false;
            demon = -1;
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
        AudioJungle = GetComponent<AudioSource>();
        p = GameObject.Find("Player").GetComponent<player>();
        demonJumpscare = GameObject.Find("DemonPoly");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart && !victory)
        {
            //timer system
            timer -= Time.deltaTime;
        // print(timer);
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");
            timerText.text = minutes + ":" + seconds;

            if (timer <= 0)
            {
                isWin[0] = true;
                if (!isWin[1])
                {
                    victory = false;
                    JumpScare();
                }
                else
                    victory = true;
                CounterEvent();
                print("game should end");
            }
            if (fluteCounter > 0)
            {
                fluteCounter -= Time.deltaTime;
            }

            if (demonDistance == null && !victory)// Check if no cooldown is active.
            {
                demonDistance = StartCoroutine(Timers(0,10f));
            }
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
