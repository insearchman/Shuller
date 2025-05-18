using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    private const string TRIGGER = "play";
    private const float INVOKE_TIME = 0.1f;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayNextStep()
    {
        _animator.SetTrigger(TRIGGER);
        Invoke("ResetTrigger", INVOKE_TIME);
    }

    private void ResetTrigger()
    {
        _animator.ResetTrigger(TRIGGER);
    }
}