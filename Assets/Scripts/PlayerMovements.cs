using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("Movements")]
    [SerializeField]float moveSpeed;
    
    [SerializeField] float groundDrag;

    [Header("Ground Check")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask whatIsGround;
    
    private bool grounded; 
    [SerializeField] float jumpForce;
    [SerializeField] float jumpCoolDown;
    [SerializeField] float airMultiplier;
    [SerializeField] float gravityScale;
    private bool readyToJump;

    [Header("Key Binds")]
    [SerializeField] KeyCode jumpKeys = KeyCode.Space;
    [SerializeField]Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDir;

    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    private void Update() {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        
        MyInput();
        SpeedControl();

        // handle drag 
        if(grounded){
            rb.drag = groundDrag;
        }
        else
            rb.drag = 0;//0

    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKeys) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCoolDown);
        }   
    }

    private void MovePlayer() //(1, 0, 0)
    {
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        // on ground
        if(grounded)
            rb.AddForce(moveDir * moveSpeed * 10f, ForceMode.Force);

        //in air
        else if(!grounded)
            rb.AddForce(moveDir * moveSpeed * airMultiplier *2.5f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x , 0f, rb.velocity.z);
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        rb.AddForce(-transform.up * gravityScale, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
