using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Player))]
public class PlayerMovement: MonoBehaviour {

    public float speed = 5f;
    public float jumpHeight = 2f;
    public float jumpPower = 12f;
    public float groundCheckDistance = 1.3f;
    public float dashDistance = 5f;
    public LayerMask ground;

    Animator anim;
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
    bool walking;
    float capsuleHeight;
    Vector3 capsuleCenter;
    CapsuleCollider capsule;
    bool crouching;
    bool dashing;
    Vector3 direction = Vector3.down;


    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        capsuleHeight = capsule.height;
        capsuleCenter = capsule.center;
        origGroundCheckDistance = groundCheckDistance;
    }

    void Update()
    {
        /*
        if (Input.GetButtonDown("Dash"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * rigidbody.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rigidbody.drag + 1)) / -Time.deltaTime)));
            rigidbody.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
        */
        //Debug.Log(crouching);

        //if (isGrounded && Input.GetKeyDown(GameManager.GM.crouch))
        //{
        //    if (crouching)
        //    {
        //        capsule.height = capsuleHeight;
        //        capsule.center = capsuleCenter;
        //        crouching = false;
        //    }
        //    else
        //    {
        //        capsule.height = capsule.height / 2f;
        //        capsule.center = capsule.center / 2f;
        //        crouching = true;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.X)) anim.SetTrigger("BasicAttack");
    }


    public void Move(Vector3 move, bool jump, bool dash, bool crouch)
    {
        if (move.magnitude > 1f) move.Normalize();
        CheckGroundStatus();
        move = Vector3.ProjectOnPlane(move, groundNormal);
        if(move == Vector3.zero)
        {
            walking = false;
        }
        else
        {
            walking = true;
        }
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
        //Debug.Log(dash);
        //Debug.Log(capsuleHeight);
        //Debug.Log(capsule.height);
        ScaleCapsuleForCrouching(crouch);
        //ScaleCapsuleForDashing(dash);
        //PreventStandingInLowHeadroom();
        UpdateAnimator(move, jump);
    }

    void UpdateAnimator(Vector3 move, bool jump)
    {
        anim.SetBool("Walking", walking);
        anim.SetBool("Grounded", isGrounded);
    }

    void GroundMovement(bool jump, bool dash, bool crouch)
    {
        if (jump && !crouching)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpPower, rigidbody.velocity.z);
            isGrounded = false;

            //anim
            
            groundCheckDistance = 1.3f;
        }
    }

    void AirMovement()
    {
        Vector3 extraGravityForce = (Physics.gravity * gravityMultiplier) - Physics.gravity;
        rigidbody.AddForce(extraGravityForce);

        groundCheckDistance = rigidbody.velocity.y < 0 ? origGroundCheckDistance : 1.3f;
    }

    void ScaleCapsuleForCrouching(bool crouch)
    {
        if(isGrounded && crouch)
        {
            //if (dashing)
            //{
            //    return;
            //}
            if (crouching)
            {
                capsule.height = capsuleHeight;
                capsule.center = capsuleCenter;
                crouching = false;
            }
            else
            {
                capsule.height = capsule.height / 2f;
                capsule.center = capsule.center / 2f;
                crouching = true;
            }
            
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
    }

    void PreventStandingInLowHeadroom()
    {
        if (!crouching)
        {
            Ray crouchRay = new Ray(rigidbody.position + Vector3.up * capsule.radius * half, Vector3.up);
            float crouchRayLength = capsuleHeight * half - capsule.radius * half;
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
        if (crouching)
        {
            if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance * half))
            {
                groundNormal = hitInfo.normal;
                isGrounded = true;
                
            }
            else
            {

                isGrounded = false;
                groundNormal = Vector3.up;
                
            }
        }

            if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance))
            {
                groundNormal = hitInfo.normal;
                isGrounded = true;
                
            }
            else
            {

                isGrounded = false;
                groundNormal = Vector3.up;
               
            }
        
        
        
    }
}
