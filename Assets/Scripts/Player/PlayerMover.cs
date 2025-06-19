using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private Transform _transform;
    private CharacterController _characterController;

    private void Awake()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(float verticalAxis, float horizontalAxis)
    {
        if (_characterController != null)
        {
            Vector3 movement = _transform.forward * verticalAxis * _speed + _transform.right * horizontalAxis * _speed;
            movement *= Time.deltaTime;

            if (_characterController.isGrounded)
            {
                _characterController.Move(movement + Physics.gravity);
            }
            else
            {
                _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
            }
        }
    }
}