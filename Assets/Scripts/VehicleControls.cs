using UnityEditor.Callbacks;
using UnityEngine;

public class VehicleControls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _force = 1f;

    [SerializeField] private float _torque = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void FixedUpdate()
    {
        // if the player presses 's' increase the downward velocity of the rigidbody
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
        
    }
}
