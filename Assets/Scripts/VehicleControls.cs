using UnityEngine;

public class VehicleControls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _force = 1f;
    [SerializeField] private float _torque = 1f;

    [SerializeField] private float _boostForce = 1f;

    private void FixedUpdate()
    {
        // if the player presses 's' increase the downward velocity
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(Vector2.down * _force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddTorque(1f * _torque);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddTorque(-1f * _torque);
        }

        // horizontal boost when pressing Left Shift
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(Vector2.right * _boostForce);
        }
    }
}
