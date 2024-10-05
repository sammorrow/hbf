using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public float Speed = 7f;

    private float _horizontalInput;
    private float _verticalInput;


    [SerializeField] private CharacterController _characterController;


    void Start()
    {    }

    void FixedUpdate()
    {
        Move();

        // Shoot logic TBD
      
    }

    private void Move()
    {
        _horizontalInput = _horizontalInput < 0 ? -1 : Mathf.Ceil(_horizontalInput);
        _verticalInput = _verticalInput < 0 ? -1 : Mathf.Ceil(_verticalInput);

        Vector3 movementVector = new Vector3( Input.GetAxis("Horizontal") , 0 , Input.GetAxis("Vertical") );



        _characterController.Move(movementVector * Speed * Time.deltaTime);

    }
}
