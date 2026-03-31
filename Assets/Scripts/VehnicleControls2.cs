using UnityEngine;

public class VehicleControls2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _force = 1f;
    [SerializeField] private float _torque = 1f;

    [SerializeField] private float _jumpForce = 1f;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private bool _isGrounded;

    private void Awake()
    {
        PowerupManager.Instance.players[1] = _rb;
    }
    
    private void Update()
    {
        // Check if touching ground
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

        // Jump when pressing W and grounded
        if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _rb.AddForce(Vector2.down * _force);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.AddTorque(1f * _torque);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.AddTorque(-1f * _torque);
        }
    }

    // Optional: visualize ground check in editor
    private void OnDrawGizmosSelected()
    {
        if (_groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
        }
    }
}
