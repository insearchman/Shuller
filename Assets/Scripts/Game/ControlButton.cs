using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    [SerializeField] private GameCardsStateControl _gameCardsStateControl;

    private Button _button;

    private const float _animationLeght = 0.5f;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _button.enabled = false;
        Invoke("EnableButton", _animationLeght);

        _gameCardsStateControl.StartAnimation(name);
    }

    private void EnableButton() => _button.enabled = true;
}