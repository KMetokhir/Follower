using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed=3;
    [SerializeField] private float _horizontalTurnSensitivity = 4;

    private Transform _transform;
    private CharacterController _characterController;

    private void Awake()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_characterController != null)
        {
            Vector3 forward = Vector3.ProjectOnPlane(_transform.forward, Vector3.up).normalized;
            Vector3 right = Vector3.ProjectOnPlane(_transform.right, Vector3.up).normalized;

           /* Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Vector3 playerSpeed= playerInput*_speed*Time.deltaTime;*/

            Vector3 movement = forward * Input.GetAxis("Vertical") * _speed + right* Input.GetAxis("Horizontal") * _speed;
            movement *= Time.deltaTime;

            transform.Rotate(Vector3.up * _horizontalTurnSensitivity * Input.GetAxis("Mouse X"));

            if (_characterController.isGrounded)
            {
                _characterController.Move(movement + Physics.gravity);
            }
            else
            {
                _characterController.Move(_characterController.velocity + Physics.gravity*Time.deltaTime);
            }
        }
    }
}
