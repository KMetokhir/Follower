using UnityEngine;

public class FollowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private Transform _transform;

    private void OnValidate()
    {
        _rotationSpeed = Mathf.Abs(_rotationSpeed);
    }

    private void Awake()
    {
        _transform = transform;
    }

    public void RotateTo(Vector3 target)
    {
        target = new Vector3(target.x, _transform.position.y, target.z);
        Vector3 relativePos = target - _transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePos, Vector3.up);

        _transform.rotation = Quaternion.Lerp(_transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}