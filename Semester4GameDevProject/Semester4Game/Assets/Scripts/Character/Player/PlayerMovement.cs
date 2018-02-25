using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour {

    public float speed = 6f;
    public float jumpForce = 3f;
    public float isGroundedOffsett;
    public float turnSmoothing = 15f;

    float distToGround;
    Vector3 jump;
    Vector3 movement;
    Animator animate;
    Rigidbody playerRigidbody;

	void Awake () {

        playerRigidbody = GetComponent<Rigidbody>();
        jump = new Vector3(0f, jumpForce, 0f);
	}
	
	void FixedUpdate () {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Move(x, z);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            playerRigidbody.AddForce(jump, ForceMode.Impulse);
        }


        //Animating(x, z);
	}

    void Move(float x, float z)
    {
        movement.Set(x, 0f, z);
        //movement = Camera.main.transform.TransformDirection(movement);

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(playerRigidbody.position + movement);

        if(x != 0f || z != 0f)
        {
            Rotating(x, z);
        }
    }

    void Rotating(float x, float z)
    {
        Vector3 targetDirection = new Vector3(x, 0f, z);

        Quaternion targetRotation = Quaternion.LookRotation(movement, playerRigidbody.transform.up);
        movement.y = 0f;
        Quaternion newRotation = Quaternion.Lerp(playerRigidbody.transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        playerRigidbody.MoveRotation(newRotation);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + isGroundedOffsett);
    }
}
