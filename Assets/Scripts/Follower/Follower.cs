using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody))]
public class Follower : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _distanceOffset;
    [SerializeField] private GroundChecker _groundChecker;

    private bool _isMoving = false;
    [SerializeField]  private Transform _target;

    private void OnValidate()
    {
        _speed = Mathf.Abs(_speed);
    }

    private void Awake()
    {
        StartFollow(_target);
    }

    public void StartFollow(Transform target)
    {
        _isMoving = true;
        _target = target;
    }

    private void StopMoving()
    {
        _isMoving = false;
    }

    private float GetSqrDistance(Vector3 ownerPosition, Vector3 targetPosition)
    {
        targetPosition = new Vector3(targetPosition.x, ownerPosition.y, targetPosition.z);

        return (targetPosition - ownerPosition).sqrMagnitude;
    }

    private void RotateTo(Vector3 target)
    {
        target = new Vector3(target.x, transform.position.y, target.z);
        Vector3 relativePos = target - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePos, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        if (_groundChecker.IsGrounded)
        {
            Debug.Log("MOVE");
           
            Vector3 forward = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
            Vector3 velocity = new Vector3(forward.x * _speed, _rigidbody.velocity.y, forward.z * _speed);
            _rigidbody.velocity = velocity;
        }
        else
        {
            Debug.Log("NOT MOVE");

        }
    }

    private void Update()
    {
        if (_isMoving)
        {
            Move();
            RotateTo(_target.position);

            float sqrDistance = GetSqrDistance(transform.position, _target.position);

            if (sqrDistance <= _distanceOffset)
            {
                StopMoving();
            }
        }
    }
}

