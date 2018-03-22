using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Player))]
public class PlayerMovement: MonoBehaviour {

    public float speed = 5f;
    public float jumpHeight = 2f;
    public float jumpPower = 12f;
    public float groundCheckDistance = 0.1f;
    public float dashDistance = 5f;
    public LayerMask ground;

    Transform cam;                 
    Vector3 camForward;             
    Rigidbody rigidbody;            
    Vector3 inputs = Vector3.zero;
    bool isGrounded;
    Vector3 groundNormal;
    float origGroundCheckDistance;
    [Range(1f, 4f)] float gravityMultiplier = 2f;
    const float half = 0.5f;
    float turnAmount;
    float capsuleHeight;
    Vector3 capsuleCenter;
    CapsuleCollider capsule;
    bool crouching;
    bool dashing;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        capsuleHeight = capsule.height;
        capsuleCenter = capsule.center;
        origGroundCheckDistance = groundCheckDistance;
    }

    void Update()
    {
        /*
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //rigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            //rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Dash"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * rigidbody.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rigidbody.drag + 1)) / -Time.deltaTime)));
            rigidbody.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
        */
    }


    public void Move(Vector3 move, bool jump, bool dash, bool crouch)
    {
        if (move.magnitude > 1f) move.Normalize();
        CheckGroundStatus();
        move = Vector3.ProjectOnPlane(move, groundNormal);
        if (move != Vector3.zero)
        {
            // makes the character look in the direction it is walking
            transform.rotation = Quaternion.LookRotation(move);
        }
        
        rigidbody.MovePosition(rigidbody.position + move * speed * Time.deltaTime);

        if (isGrounded)
        {
            GroundMovement(jump, dash, crouch);
        }
        else
        {
            AirMovement();
        }

        ScaleCapsuleForCrouching(crouch);
        PreventStandingInLowHeadroom();
    }

    void GroundMovement(bool jump, bool dash, bool crouch)
    {
        if (jump && !crouch && !dash)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpPower, rigidbody.velocity.z);
            isGrounded = false;
            //animator.applyRootMotion = false;
            groundCheckDistance = 1.1f;
        }
    }

    void AirMovement()
    {
        Vector3 extraGravityForce = (Physics.gravity * gravityMultiplier) - Physics.gravity;
        rigidbody.AddForce(extraGravityForce);

        groundCheckDistance = rigidbody.velocity.y < 0 ? origGroundCheckDistance : 0.01f;
    }

    void ScaleCapsuleForCrouching(bool crouch)
    {
        if(isGrounded && crouch)
        {
            if (crouching || dashing)
            {
                return;
            }
            capsule.height = capsule.height / 2f;
            capsule.center = capsule.center / 2f;
            crouching = true;
        }
        else
        {
            Ray crouchRay = new Ray(rigidbody.position + Vector3.up * capsule.radius * half, Vector3.up);
            float crouchRayLength = capsuleHeight - capsule.radius * half;
            if(Physics.SphereCast(crouchRay, capsule.radius * half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
            {
                crouching = true;
                return;
            }
            capsule.height = capsuleHeight;
            capsule.center = capsuleCenter;
            crouching = false;
        }
    }

    void ScaleCapsuleForDashing(bool dash)
    {
        if (isGrounded && dash)
        {
            if (dashing)
            {
                return;
            }
            capsule.height = capsule.height / 2f;
            capsule.center = capsule.center / 2f;
            dashing = true;
        }
        else
        {
            Ray dashRay = new Ray(rigidbody.position + Vector3.up * capsule.radius * half, Vector3.up);
            float dashRayLength = capsuleHeight - capsule.radius * half;
            if (Physics.SphereCast(dashRay, capsule.radius * half, dashRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
            {
                dashing = true;
                return;
            }
            capsule.height = capsuleHeight;
            capsule.center = capsuleCenter;
            dashing = false;
        }
    }

    void PreventStandingInLowHeadroom()
    {
        if (!crouching)
        {
            Ray crouchRay = new Ray(rigidbody.position + Vector3.up * capsule.radius * half, Vector3.up);
            float crouchRayLength = capsuleHeight - capsule.radius * half;
            if(Physics.SphereCast(crouchRay, capsule.radius * half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
            {
                crouching = true;
            }
        }
    }

    void CheckGroundStatus()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * groundCheckDistance));
#endif
        // 0.1f is a small offset to start the ray from inside the character
        // it is also good to note that the transform position in the sample assets is at the base of the character
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance))
        {
            groundNormal = hitInfo.normal;
            isGrounded = true;
            //animator.applyRootMotion = true;
        }
        else
        {
            
            isGrounded = false;
            groundNormal = Vector3.up;
            //animator.applyRootMotion = false;
        }
        
    }
}
