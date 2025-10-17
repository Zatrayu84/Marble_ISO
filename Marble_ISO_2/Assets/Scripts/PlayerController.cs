using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("======== STATS ========")]
    [SerializeField] [Range (1, 20)] float speed;
    [SerializeField] [Range(1, 20)] float jumpForce;
    
    [Header("======== CAMERA ========")]
    [SerializeField] Camera mainCamera;
    public bool hasPowerup = false;
    
    public Rigidbody playerRb;
    public GameObject powerupIndicator;
    public float horizontalInput;
    public float verticalInput;
    private bool jumpInput;
    
    private Vector3 movementInput;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        powerupIndicator.transform.position = transform.position + 
        new Vector3(0, 1.0f, 0);
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
        movementInput = new Vector3(horizontalInput, 0, verticalInput);
        
        if(Input.GetButtonDown("Jump"))
        {
            jumpInput = true;
        }
    }
    void MovementPhysics()
    {
        if (movementInput.magnitude > 0.01f)
        {
            // Get the camera's forward vector
            Vector3 camForward = mainCamera.transform.forward;
            camForward.y = 0;
            camForward.Normalize(); 

            // Get the camera's right vector
            Vector3 camRight = mainCamera.transform.right;
            camRight.y = 0;
            camRight.Normalize();
            
            // this is where I get my movement direction
            Vector3 moveDirection = (camForward * verticalInput + camRight * horizontalInput).normalized;
            playerRb.AddForce(moveDirection * speed, ForceMode.Acceleration);
            
            //This is where I can stop my sliding
            Vector3 flatVelocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
            
            if(flatVelocity.magnitude > speed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * speed;
                playerRb.velocity = new Vector3(limitedVelocity.x, playerRb.velocity.y, limitedVelocity.z);
            }
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
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        powerupIndicator.gameObject.SetActive(true);
        Debug.Log("Powerup is now turned on");
        hasPowerup = true;
        jumpForce *= 2;
        StartCoroutine(powerupTimerRoutine());
    }
    IEnumerator powerupTimerRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        jumpForce = 10.0f;
        powerupIndicator.gameObject.SetActive(false);
    }
}
