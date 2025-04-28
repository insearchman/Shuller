using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _imageSelected;
    [SerializeField] private GameCardsStateControl _cardStateControl;

    private Animator _animator;
    private AudioSource _audioSource;

    private bool _isSelected = false;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);

        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnClick()
    {
        _isSelected = !_isSelected;
        _imageSelected.color = _isSelected ? Color.white : Color.clear;
        _cardStateControl.SetSelected(this, _isSelected);
        _audioSource.Play();
    }

    public void CancelSelection()
    {
        _isSelected = false;
        _imageSelected.color = Color.clear;
    }

    public void SetDiscard(bool onDiscard)
    {
        _animator.SetBool("onDiscard", onDiscard);
    }
}