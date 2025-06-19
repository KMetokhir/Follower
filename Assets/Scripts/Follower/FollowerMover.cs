using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(GroundChecker))]
public class FollowerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private GroundChecker _groundChecker;
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void OnValidate()
    {
        _speed = Mathf.Abs(_speed);
    }

    private void Awake()
    {
        _groundChecker = GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    public void Move()
    {
        if (_groundChecker.IsGrounded)
        {
            Vector3 velocity = new Vector3(_transform.forward.x * _speed, _rigidbody.velocity.y, _transform.forward.z * _speed);
            _rigidbody.velocity = velocity;
        }
    }

    public void StopMoving()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}
