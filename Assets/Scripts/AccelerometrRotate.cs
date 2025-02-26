using System;
using UnityEngine;
using UnityEngine.UI;

public class AccelerometrRotate : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private Image _image;

    private float force;
    private float angle;
    private float prev_angle = 0f;
    private float multiplier = 5f;
    private float shaking = 0.2f;
    private float boost = 5f;

    private float speed;
    private Color newColor;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        newColor = _image.color;
    }

    private void FixedUpdate()
    {
        angle = Input.acceleration.x;
        force = -(angle - prev_angle) * multiplier;

        if (force > shaking | force < -shaking)
        {
            if (angle > 0 && prev_angle < 0)
            {
                force *= boost;
            }
            else if (angle < 0 && prev_angle > 0)
            {
                force *= boost;
            }
            _rb.AddTorque(force);
        }

        if (Input.touchCount > 0)
        {
            _rb.AddTorque(boost);
        }

        prev_angle = angle;
    }

    private void Update()
    {
        speed = Math.Abs(_rb.angularVelocity);
        if (speed > (multiplier * 100)) speed = (multiplier * 100);
        newColor.a = speed > 0 ? 1 / (multiplier * 100 / speed) : 0;
        _image.color = newColor;
    }
}
