using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteLookAt : MonoBehaviour
{
    Transform lookPos;
    // Start is called before the first frame update
    void Start()
    {
        lookPos = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(lookPos.position);
    }
}
