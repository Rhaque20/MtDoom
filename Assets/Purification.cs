using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Purification : MonoBehaviour
{
    Transform lookPos;
    float progress = 0f;
    GameObject progressDisplay;
    // Start is called before the first frame update
    void Start()
    {
        lookPos = Camera.main.transform;
        progressDisplay = this.transform.Find("Progress").gameObject;
    }

    public void OnTriggerStay(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            print("PURIFYING!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        progressDisplay.transform.localRotation = Quaternion.LookRotation(transform.position - lookPos.position);
    }
}
