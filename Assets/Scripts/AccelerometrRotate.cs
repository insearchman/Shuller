using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AccelerometrRotate : MonoBehaviour
{
    private const float MULTIPLIER = 5.0f;
    private const float SHAKING = 0.2f;
    private const float BOOST = 5.0f;

    private Rigidbody2D _chip0RB;
    private float _force;
    private float _angle;
    private Vector3 _anglev;
    private float _prev_angle = 0.0f;

    //Debug
    [SerializeField]
    public Object _text;

    private void Start()
    {
        _chip0RB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _angle = Input.acceleration.x;
        _anglev = Input.acceleration;
        _force = -(_angle - _prev_angle) * MULTIPLIER;

        if (_force > SHAKING | _force < -SHAKING)
        {
            if (_angle > 0 && _prev_angle < 0)
            {
                _force *= BOOST;
            }
            else if (_angle < 0 && _prev_angle > 0)
            {
                _force *= BOOST;
            }
            _chip0RB.AddTorque(_force);
        }

        _prev_angle = _angle;
    }
}