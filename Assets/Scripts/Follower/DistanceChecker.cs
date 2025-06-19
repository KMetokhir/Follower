using System;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    [SerializeField] private float _distanceOffset;

    private bool _distanceOffsetReached = false;

    public event Action DistanceOffsetReached;
    public event Action OutOfDistanceOffset;

    private void OnValidate()
    {
        _distanceOffset = Mathf.Abs(_distanceOffset);
    }

    public void ProcessDistance(Vector3 ownerPosition, Vector3 targetPosition)
    {
        float sqrDistance = GetSqrDistance(ownerPosition, targetPosition);

        if (sqrDistance <= _distanceOffset)
        {
            if (_distanceOffsetReached == false)
            {
                DistanceOffsetReached?.Invoke();
                _distanceOffsetReached = true;
            }
        }
        else
        {
            if (_distanceOffsetReached)
            {
                OutOfDistanceOffset?.Invoke();
                _distanceOffsetReached = false;
            }
        }
    }

    private float GetSqrDistance(Vector3 ownerPosition, Vector3 targetPosition)
    {
        targetPosition = new Vector3(targetPosition.x, ownerPosition.y, targetPosition.z);

        return (targetPosition - ownerPosition).sqrMagnitude;
    }
}