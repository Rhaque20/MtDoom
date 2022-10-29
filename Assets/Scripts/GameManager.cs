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

    int ritualProgress;
    [SerializeField]
    float timer=360;
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
        timer -= Time.deltaTime;
        print(timer);
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        timerText.text = minutes + ":" + seconds;

    }


    public void Flute()
    {
        print("Flute action");
    }

   

}
