using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("======== STATS ========")]
    [SerializeField] [Range (1, 20)] float speed;
    [SerializeField] [Range(1, 20)] float jumpForce;
    
    public Rigidbody playerRb;
    public float horizontalInput;
    public float verticalInput;
    private bool jumpInput;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    // FixedUpdate is called at fixed time intervals (essential for physics)
    void FixedUpdate()
    {
        MovementPhysics();
    }
    
    void MovementInput()
    {
        // Read the input values
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        if(Input.GetButtonDown("Jump"))
        {
            jumpInput = true;
        }
    }
    void MovementPhysics()
    {
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        playerRb.AddForce(moveDirection * speed, ForceMode.Acceleration);
        
        //This is where i can stop my sliding
        Vector3 flatVelocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
        
        if(flatVelocity.magnitude > speed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * speed;
            playerRb.velocity = new Vector3(limitedVelocity.x, playerRb.velocity.y, limitedVelocity.z);
        }
        
        Jump();
    }
    
    void Jump()
    {
        if(jumpInput && Mathf.Abs(playerRb.velocity.y) < 0.01f)
        {
            Debug.Log("Jump key was pressed");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpInput = false;
        }
        if (jumpInput)
        {
            jumpInput = false;
        }
    }
}
