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
    public AudioSource audiosource;
    public AudioClip footsteps;
    public AudioClip pickupSound;
    public AudioClip placeSound;
    public AudioClip paperPickup;
    public AudioClip paperPlace;
    bool isWalking = false;
    public Interactable item
    {
        get{return grabbedItem;}
    }
    private void Awake()
    {
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStart)
        {
        //movement system
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveVector = this.transform.TransformDirection(moveVector);
        controller.SimpleMove(moveVector*speed);

        // footstep sounds
        if (Input.GetKey(KeyCode.W) && isWalking == false)
        {
            audiosource.clip = footsteps;
            audiosource.loop = true;
            audiosource.Play();
            isWalking = true;
        }
        if (Input.GetKeyUp(KeyCode.W) && isWalking == true)
        {
            audiosource.Stop();
            audiosource.loop = false;
            isWalking = false;
        }
        if (Input.GetKey(KeyCode.S) && isWalking == false)
        {
            audiosource.clip = footsteps;
            audiosource.loop = true;
            audiosource.Play();
            isWalking = true;
        }
        if (Input.GetKeyUp(KeyCode.S) && isWalking == true)
        {
            audiosource.Stop();
            audiosource.loop = false;
            isWalking = false;
        }
        if (Input.GetKey(KeyCode.A) && isWalking == false)
        {
            audiosource.clip = footsteps;
            audiosource.loop = true;
            audiosource.Play();
            isWalking = true;
        }
        if (Input.GetKeyUp(KeyCode.A) && isWalking == true)
        {
            audiosource.Stop();
            audiosource.loop = false;
            isWalking = false;
        }
        if (Input.GetKey(KeyCode.D) && isWalking == false)
        {
            audiosource.clip = footsteps;
            audiosource.loop = true;
            audiosource.Play();
            isWalking = true;
        }
        if (Input.GetKeyUp(KeyCode.D) && isWalking == true)
        {
            audiosource.Stop();
            audiosource.loop = false;
            isWalking = false;
        }

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
                        if (interactable.tag == "Paper")
                        {
                            audiosource.clip = paperPickup;
                            audiosource.Play();
                            
                        }
                        else
                        {
                            audiosource.clip = pickupSound;
                            audiosource.Play();
                        }
                        if(grabbedItem != null)
                        {
                            if(interactable.tag == "Paper")
                            {
                                audiosource.clip = paperPlace;
                                audiosource.Play();
                                //audiosource.clip = paperPlace;
                            }
                            else
                            {
                                audiosource.clip = placeSound;
                                audiosource.Play();
                            }
                            grabbedItem.returnObject();
                            grabbedItem = null;
                        }
                        interactable.grab(grabPos);

                        grabbedItem = interactable;
                    }
                    else
                    {
                        if(grabbedItem!=null && grabbedItem.interactionCode != 0)
                        {
                            interactable.ItemInteraction(grabbedItem);
                        }
                        else
                        {
                            interactable.Interaction();
                        }
                        

                    }
                    
                }else
                if (Input.GetKey(KeyCode.E)&& interactable.longInteraction)
                {
                    interactable.HeldInteraction();
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
                audiosource.Play();
            }
        }
        if (grabbedItem != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                grabbedItem.Interaction();
            }
            else if (Input.GetMouseButton(0))
            {
                grabbedItem.HeldInteraction();
            }else if (Input.GetMouseButtonUp(0))
            {
                grabbedItem.releasedInteraction();
            }
        }
        //drops/returns the object
        }

    }
}
