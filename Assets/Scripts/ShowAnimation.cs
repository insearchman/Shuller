using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowAnimation : MonoBehaviour
{
    protected Animator _animator;
    protected Button _button;
    protected AudioSource _audioSource;

    protected float _animationLeght;

    protected void Start()
    {
        _animator = GetComponent<Animator>();
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Show()
    {
        _animator.SetBool("onTable", !_animator.GetBool("onTable"));
        SetButtonActive(_animator.GetBool("onTable"));
    }

    public void Show(bool onTable)
    {
        _animator.SetBool("onTable", onTable);
        SetButtonActive(onTable);
    }

    protected void SetButtonActive(bool active)
    {
        if (_button)
        {
            if (active)
            {
                _animationLeght = Math.Abs(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
                Invoke("EnableButton", _animationLeght);
            }
            else
            {
                _button.enabled = false;
            }
        }
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }

    protected void EnableButton() => _button.enabled = true;
}