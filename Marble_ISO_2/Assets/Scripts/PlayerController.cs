using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range (1, 20)] float speed;
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
    }
    void MovementPhysics()
    {
        playerRb.MovePosition(transform.position + playerMove * speed * Time.deltaTime);
        
        
        //This is where we are going to add the torque to make the ball roll at a later time
        /*Vector3 torque = Vector3.Cross(Vector3.up, playerMove).normalized;
        playerRb.AddTorque(torque, ForceMode.Acceleration);*/
    }
}
