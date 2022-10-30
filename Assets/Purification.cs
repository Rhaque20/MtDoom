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
            player p = player.gameObject.GetComponent<player>();
            if (p.item != null && p.item.interactionCode == 2)
            {
                print("PURIFYING!");
                progress += 2*Time.deltaTime;
                if (progress >= 100f)
                {
                    progress = 100f;
                    GameManager.Instance.PurificationComplete();
                }
                progressDisplay.GetComponent<TMP_Text>().text = Mathf.Floor(progress).ToString()+"%";
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        progressDisplay.transform.localRotation = Quaternion.LookRotation(transform.position - lookPos.position);
    }
}
