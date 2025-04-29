using UnityEngine;
using UnityEngine.InputSystem;

public class AccelerometrRotate : MonoBehaviour
{
    private const float SHAKING = 1.0f;
    private const float BOOST = 10.0f;

    private Rigidbody2D _chip0;

    private float _force;
    private float _accelerationX;
    private float _prev_accelerationX = 0.0f;

    private void Start()
    {
        _chip0 = GetComponent<Rigidbody2D>();

        InputSystem.EnableDevice(Accelerometer.current);
    }

    private void FixedUpdate()
    {
        _accelerationX = Accelerometer.current.acceleration.ReadValue().x;
        _force = -(_accelerationX - _prev_accelerationX);

        if (_force > SHAKING | _force < -SHAKING)
        {
            if (_accelerationX > 0 && _prev_accelerationX < 0)
            {
                _force *= BOOST;
            }
            else if (_accelerationX < 0 && _prev_accelerationX > 0)
            {
                _force *= BOOST;
            }
            _chip0.AddTorque(_force);
        }

        _prev_accelerationX = _accelerationX;
    }
}