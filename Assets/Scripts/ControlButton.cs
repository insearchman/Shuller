using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    [SerializeField]
    private GameCardsStateControl _gameCardsStateControl;

    protected Button _button;
    protected AudioSource _audioSource;

    private const float _animationLeght = 0.3f;

    protected void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        _audioSource.Play();

        _button.enabled = false;
        Invoke("EnableButton", _animationLeght);

        _gameCardsStateControl.StartAnimation(name);
    }

    protected void EnableButton() => _button.enabled = true;
}