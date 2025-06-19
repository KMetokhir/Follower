using UnityEngine;

[RequireComponent(typeof(FollowerMover), typeof(DistanceChecker), typeof(FollowerRotator))]
public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private DistanceChecker _distanceChecker;
    private bool _targetReached = false;

    private FollowerMover _mover;
    private FollowerRotator _rotator;

    private void OnEnable()
    {
        _distanceChecker.DistanceOffsetReached += OnTargetReached;
        _distanceChecker.OutOfDistanceOffset += OnTargetLost;
    }

    private void OnDisable()
    {
        _distanceChecker.DistanceOffsetReached -= OnTargetReached;
        _distanceChecker.OutOfDistanceOffset -= OnTargetLost;
    }

    private void Awake()
    {
        _distanceChecker = GetComponent<DistanceChecker>();
        _mover = GetComponent<FollowerMover>();
        _rotator = GetComponent<FollowerRotator>();
    }

    private void OnTargetLost()
    {
        _targetReached = false;
    }

    private void OnTargetReached()
    {
        _mover.StopMoving();
        _targetReached = true;
    }

    private void FixedUpdate()
    {
        _distanceChecker.ProcessDistance(transform.position, _target.position);

        if (_targetReached == false)
        {
            _mover.Move();
        }
    }

    private void Update()
    {
        _rotator.RotateTo(_target.position);
    }
}