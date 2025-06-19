using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _horizontalTurnSensitivity = 4;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Rotate(float axise)
    {
        _transform.Rotate(Vector3.up * _horizontalTurnSensitivity * axise);
    }
}