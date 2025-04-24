using System;

public class OptionsButton : ShowAnimation
{
    public void Open()
    {
        _button.enabled = false;
        _animator.SetTrigger("Open");
        _animationLeght = Math.Abs(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.length) / 2;
        Invoke("EnableButton", _animationLeght);
        _audioSource.Play();
    }
}