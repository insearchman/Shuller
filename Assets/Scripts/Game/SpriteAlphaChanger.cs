using System;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAlphaChanger : MonoBehaviour
{
    private const float SPEEDLIMIT = 500.0f;

    private Rigidbody2D _chip3;
    private Image _chip3Image;
    private Color _newColor;
    private float _speed;

    private void Start()
    {
        _chip3 = GetComponentInParent<Rigidbody2D>();
        _chip3Image = GetComponent<Image>();
        _newColor = _chip3Image.color;
    }

    private void Update()
    {
        _speed = Math.Abs(_chip3.angularVelocity);
        if (_speed > SPEEDLIMIT) _speed = SPEEDLIMIT;
        _newColor.a = _speed > 0 ? 1 / (SPEEDLIMIT / _speed) : 0;
        _chip3Image.color = _newColor;
    }
}