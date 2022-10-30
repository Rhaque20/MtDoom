using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonEvent : MonoBehaviour
{
    Collider col;
    [SerializeField]int eventID = 0;
    [SerializeField]public List<GameObject> code = new List<GameObject>();
    [SerializeField]GameObject []trueCode = new GameObject[3];

    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            player p = player.gameObject.GetComponent<player>();
            if (p.item.interactionCode == eventID)
                GameManager.Instance.CounterEvent();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (eventID == 1)
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
                    print("Correct code!");
                }
                else
                    print("Incorrect!");
                code.Clear();
            }
        }
    }
}
