using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMover), typeof(PlayerRotator))]
public class Player : MonoBehaviour
{
    private PlayerInput _input;
    private InputAction _movementInput;

    private PlayerMover _mover;
    private PlayerRotator _rotator;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _rotator = GetComponent<PlayerRotator>();

        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _movementInput = _input.Player.Movement;
        _movementInput.Enable();
    }

    private void OnDisable()
    {
        _movementInput.Disable();
    }

    private void Update()
    {
        float xAxis = _movementInput.ReadValue<Vector2>().x;
        float yAxis = _movementInput.ReadValue<Vector2>().y;

        _mover.Move(yAxis, xAxis);
        _rotator.Rotate(Mouse.current.delta.x.ReadValue());
    }
}