using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonEvent : MonoBehaviour
{
    Collider col;
    [SerializeField]int eventID = 0;

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
        
    }
}
