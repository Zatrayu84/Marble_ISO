using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Target & Speed")]
    [SerializeField] Transform target;  //Drag my ball into here
    [SerializeField] float mouseSensitivity;
    [SerializeField] float smoothSpeed = 0.125f;
    
    [Header("Positioning")]
    [SerializeField] [Range(1, 14)] float distance;
    [SerializeField] [Range(1, 20)] float height;
    [SerializeField] float lockVertMin, lockVertMax;
    
    private float currentYaw;
    private float currentPitch;
    
    void LateUpdate()
    {
        //Mouse rotation inputs here
        currentYaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        currentPitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        currentPitch = Mathf.Clamp(currentPitch, lockVertMin, lockVertMax);
        
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0);
        
        Vector3 desiredPosition = target.position + rotation * new Vector3(0, height, -distance);
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
        // Look at player center
        transform.LookAt(target.position);
    } 
}
