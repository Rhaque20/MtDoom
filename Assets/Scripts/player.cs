using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Camera cam;
    CharacterController controller;
    [SerializeField]
    float speed,interactionDistance;
    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    Image crosshair;
    [SerializeField]
    Transform grabPos;
    Interactable grabbedItem;
    private void Awake()
    {
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement system
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveVector = this.transform.TransformDirection(moveVector);
        controller.SimpleMove(moveVector*speed);

        //camera system
        this.transform.Rotate(this.transform.up * Input.GetAxis("Mouse X"));
        cam.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
        var angle = cam.transform.localEulerAngles;
        angle.z = 0;
        angle.y = 0;
        if (angle.x > 180 && angle.x < 280)
        {
            angle.x = 280;
        }
        else if (angle.x < 180 && angle.x > 80)
        {
            angle.x = 80;
        }
        cam.transform.localEulerAngles = angle;

        //interaction feature. when the player presses left click will send ray from center of screen forward, and send an interaction request with the object
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, interactionDistance, layerMask))
        {
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
            
            if (interactable != null)
            {
                crosshair.color = Color.green;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //if item is holdable do the grab Interactions
                    if (interactable.holdable)
                    {
                        if(grabbedItem != null)
                        {
                            grabbedItem.returnObject();
                            grabbedItem = null;
                        }
                        interactable.grab(grabPos);
                        grabbedItem = interactable;
                    }
                    else
                    {
                        interactable.interaction();
                    }
                    
                }

                
                
            }
            else
            {
                crosshair.color = Color.white;
                print("not interactable");
            }

        }
        else
        {
            crosshair.color = Color.white;
            if (Input.GetKeyDown(KeyCode.E) && grabbedItem != null)
            {
                grabbedItem.returnObject();
                grabbedItem = null;
            }
        }
        if (grabbedItem != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                grabbedItem.interaction();
            }
        }
        //drops/returns the object
       

    }
}
