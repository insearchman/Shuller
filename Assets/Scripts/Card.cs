using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _imageSelected;
    [SerializeField] private GameCardsStateControl _cardStateControl;

    protected AudioSource _audioSource;

    private Animator _animator;
    private bool _isSelected = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Select()
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