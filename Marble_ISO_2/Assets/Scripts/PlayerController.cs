using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("========/t STATS /t========")]
    [SerializeField] [Range (1, 20)] float speed;
    [SerializeField] [Range(1, 20)] float jumpForce;
    [SerializeField] [Range(1, 20)] float gravity;
    
    public Rigidbody playerRb;
    public float horizontalInput;
    public float verticalInput;
    private Vector3 playerMove;
    
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
        playerMove = new Vector3(horizontalInput,0, verticalInput).normalized;
        
        Jump();
        
        // add gravity after player is in the air
        
    }
    void MovementPhysics()
    {
        playerRb.MovePosition(transform.position + playerMove * speed * Time.deltaTime);
        
        
        //This is where we are going to add the torque to make the ball roll at a later time
        /*Vector3 torque = Vector3.Cross(Vector3.up, playerMove).normalized;
        playerRb.AddTorque(torque, ForceMode.Acceleration);*/
    }
    
    void Jump()
    {
        bool jump = Input.GetButtonDown("Jump");
        if(jump)
        {
            Debug.Log("Jump key was pressed");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
