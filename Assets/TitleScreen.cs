using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    bool loadTitle = true;
    [SerializeField]GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        timer.SetActive(false);
    }

    public void StartGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        loadTitle = false;
        this.gameObject.SetActive(false);
        timer.SetActive(true);
        GameManager.Instance.gameStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
