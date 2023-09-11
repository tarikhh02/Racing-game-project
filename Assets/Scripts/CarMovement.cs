using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    float clampSideMovementWidth = 1.35f;
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float rotationSpeed = 10f;

    Transform carTransform;
    Rigidbody carRb; 

    void Awake()
    {
        carTransform = GetComponent<Transform>();
        carRb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        InputManager();
        //ClampPlayerMovement();
    }

    private void ClampPlayerMovement()
    {
        float newxPos = carTransform.position.x;

        if(newxPos < 0)
            newxPos = -clampSideMovementWidth;
        else
            newxPos = clampSideMovementWidth;

        if(PlayerSidePosNeedsToBeClamped())
            carTransform.position = new Vector3(newxPos, carTransform.position.y, carTransform.position.z);

    }

    private bool PlayerSidePosNeedsToBeClamped()
    {
        float xPos = carTransform.position.x;

        if (xPos < 0)
        {
            xPos *= -1;
        }

        if (xPos > clampSideMovementWidth)
        {
            return true;
        }

        return false;
    }

    void InputManager()
    {
        Vector3 movementDirection = new Vector3();
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = 0f;
        movementDirection.z = Input.GetAxisRaw("Vertical");

        Move(movementDirection);

        if (movementDirection.x == 0 && movementDirection.z == 0)
        {
            carRb.velocity = Vector3.zero;
        }
    }

    private void Move(Vector3 direction)
    {
        float newRotaion = carTransform.rotation.y + direction.x * Time.deltaTime * rotationSpeed;

        //if(!PlayerSidePosNeedsToBeClamped())
            carRb.AddForce(direction * speed * Time.deltaTime);
        
        carTransform.transform.rotation = Quaternion.Euler(new Vector3(0, newRotaion, 0));
    }

    
}
