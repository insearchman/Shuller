using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _imageSelected;
    [SerializeField] private Image _imageState;
    [SerializeField] private GameCardsStateControl _cardStateControl;

    private Button _cardButton;
    private Animator _animator;
    private AudioSource _audioSource;

    private bool _isSelected = false;

    private void Start()
    {
        _cardButton = GetComponent<Button>();
        _cardButton.onClick.AddListener(OnClick);

        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnClick()
    {
        _audioSource.Play();
        _isSelected = !_isSelected;
        _cardStateControl.SetSelected(this, _isSelected);
        SetSelected(_isSelected);
    }

    public void SetSelected(bool onSelect)
    {
        _isSelected = onSelect;
        _imageSelected.color = onSelect ? Color.yellow : Color.clear;
    }

    public void SetToMe(bool onMe)
    {
        _imageState.color = onMe ? Color.green : Color.clear;
        SetSelected(false);
    }

    public void SetToEnemy(bool onEnemy)
    {
        _imageState.color = onEnemy ? Color.black : Color.clear;
        SetSelected(false);
    }

    public void SetDiscard(bool onDiscard)
    {
        _animator.SetBool("onDiscard", onDiscard);
        _cardButton.enabled = !onDiscard;
        SetSelected(false);
    }
}