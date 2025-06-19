using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groungCheckerRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded => Physics.OverlapSphere(_groundCheck.position, _groungCheckerRadius, _groundLayer).Length > 0;
}
