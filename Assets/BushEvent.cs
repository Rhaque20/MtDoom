using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushEvent : MonoBehaviour
{
    Collider col;

    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            player p = player.gameObject.GetComponent<player>();
            if (p.item.interactionCode == 0 && GameManager.Instance.demon == 0)
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
