using UnityEngine;
using Unity.Cinemachine;

public class DynamicCameraZoom : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _player;
    [SerializeField] private CinemachineCamera _camera;

    [Header("Ground Detection")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _rayLength = 50f;

    [Header("Zoom Settings")]
    [SerializeField] private float _minZoom = 5f;
    [SerializeField] private float _maxZoom = 15f;
    [SerializeField] private float _zoomSpeed = 5f;

    [Header("Camera Offset")]
    [SerializeField] private float _verticalOffset = -2f;

    private float _targetZoom;
    private CinemachinePositionComposer _positionComposer;

    private void Start()
    {
        if (_camera != null)
        {
            // Unity 6 replacement for FramingTransposer
            _positionComposer = _camera.GetComponent<CinemachinePositionComposer>();

            if (_positionComposer != null)
            {
                _positionComposer.TargetOffset = new Vector3(0f, _verticalOffset, 0f);
            }
        }
    }

    private void Update()
    {
        if (_player == null || _camera == null) return;

        float distanceToGround = GetDistanceToGround();

        // Normalize (0 → 1)
        float t = Mathf.InverseLerp(0f, _rayLength, distanceToGround);

        // Map to zoom
        _targetZoom = Mathf.Lerp(_minZoom, _maxZoom, t);

        // Smooth zoom
        float currentZoom = _camera.Lens.OrthographicSize;
        float newZoom = Mathf.Lerp(currentZoom, _targetZoom, Time.deltaTime * _zoomSpeed);

        _camera.Lens.OrthographicSize = newZoom;
    }

    private float GetDistanceToGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_player.position, Vector2.down, _rayLength, _groundLayer);

        if (hit.collider != null)
        {
            return hit.distance;
        }

        return _rayLength;
    }

    private void OnDrawGizmosSelected()
    {
        if (_player == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_player.position, _player.position + Vector3.down * _rayLength);
    }
}