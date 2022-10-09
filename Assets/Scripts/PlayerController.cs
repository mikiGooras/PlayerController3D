using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// to Rigidbody based controller
/// to use this script drag it on player GO
/// that include empty GO orientation and RigidBody
/// next assign references in ispector
/// to use groundcheck function ypu need to set groundlayer in inspectopr 
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed,runSpeed, groundDrag;
    public Transform orientation;
    [Header("JumpValues")]
  
    public float jumpForce, jumpcooldown, airSpeedMultiplier, jumpCounter;
    public bool readyToJump;



    [Header("GroundCheck")]
    public float playerHight;
    public LayerMask ground;
    public bool isGrounded; 
    float horizontalInput, verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

   
    void InputValue()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && readyToJump)
        {
            jumpCounter++;
            jump();
        }
        
    }
    void MoveRB()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (isGrounded) { rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force); }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airSpeedMultiplier, ForceMode.Force);
        }
    }
    void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHight * 0.5f + 0.02f, ground);

        if(jumpCounter>0 && isGrounded)
        {
            ResetJump();
        }
    }
    void DragControll(bool x)
    {
        if (x)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0f; 
        }
    }
    void speedControll()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        // limit velocity if needed
        if (flatVel.magnitude> moveSpeed)
        {
            Vector3 LimitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(LimitedVel.x, rb.velocity.y, LimitedVel.z);
        }
    }
    void jump() {

        // reset velocity in y
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //actual jump
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        
        if (jumpCounter > 0)
        {
            readyToJump = false;
        }

       

    }
    void ResetJump()
    {
        readyToJump = true;
        jumpCounter = 0;
        
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;

    }
    private void FixedUpdate()
    {
        MoveRB();
       
    }
    void Update()
    {
        InputValue();
        speedControll();
        GroundCheck();
        DragControll(isGrounded);

    }
}
