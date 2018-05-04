using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(CapsuleCollider))]
//[RequireComponent(typeof(Animator))] 

public class Player : MonoBehaviour
{
    //the games currency
    public int gold;
    public int bloodEssence;

    Rigidbody rigidbody;
    Transform cam;
    PlayerMovement charMovement;
    Vector3 move;
    Vector3 inputs = Vector3.zero;
    Vector3 camForward;
    bool jump;
    bool dash;
    bool crouch;
    public float jumpVelocity;
    public Inventory inventory;
    public ProximityInventory proximityInventory;
 
    public Player()
    {
        inventory = new Inventory();
        proximityInventory = new ProximityInventory();
    }

    void Start()
    {
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("Wardning: No main camera found.");
        }
        charMovement = GetComponent<PlayerMovement>();
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        //Debug.Log(proximityInventory.Items.Count);

        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");
        if (inputs != Vector3.zero)
        {
            // makes the characters forward equal to the inputs
            transform.forward = inputs;
        }
        //else
        //{
        //    // make the character face the camera direction if there are no inputs
        //    transform.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
        //}
        if (!jump)
        {
            jump = Input.GetKeyDown(GameManager.GM.jump);
        }

        if (!dash)
        {
            dash = Input.GetKeyDown(GameManager.GM.dash);
        }

        if (!crouch)
        {
            crouch = Input.GetKeyDown(GameManager.GM.crouch);
        }

        if (cam != null)
        {
            // calculate camera relative direction to move:
            camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            move = inputs.z * camForward + inputs.x * cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            move = inputs.z * Vector3.forward + inputs.x * Vector3.right;
        }
        //Run ?
        //if (Input.GetKey(KeyCode.LeftShift)) move *= 1.5f;

        charMovement.Move(move, jump, dash, crouch);
        jump = false;
        dash = false;
        crouch = false;
    }

    void FixedUpdate()
    {
        
       
    }

}
