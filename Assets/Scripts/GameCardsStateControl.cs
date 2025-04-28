using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameCardsStateControl : MonoBehaviour
{
    private const string ANIMATION_OPTIONS = "start_options";
    private const string ANIMATION_GAME_36 = "start_game_36";
    private const string ANIMATION_GAME_52 = "start_game_52";

    private List<Card> _selected = new();
    private List<Card> _discarded = new();

    private Animator _animator;
    private string _currentAnimationName;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartAnimation(string buttonName)
    {
        switch (buttonName)
        {
            case "Home":
                ResetAll();
                break;
            case "Game Mode 36":
                _currentAnimationName = ANIMATION_GAME_36;
                break;
            case "Game Mode 52":
                _currentAnimationName = ANIMATION_GAME_52;
                break;
            case "Options":
                _currentAnimationName = ANIMATION_OPTIONS;
                break;
            default:
                Debug.Log($"{this} - {System.Reflection.MethodBase.GetCurrentMethod().Name}: Unexpected parameter = {buttonName}");
                break;
        }
        _animator.SetTrigger(_currentAnimationName);
    }

    public void SetSelected(Card sender, bool isSelected)
    {
        if (isSelected)
        {
            _selected.Add(sender);
        }
        else
        {
            _selected.Remove(sender);
        }
    }

    public void CancelSelected()
    {
        foreach (Card card in _selected)
            card.CancelSelection();
        _selected.Clear();
    }

    public void DiscardSelected()
    {
        foreach (Card card in _selected)
        {
            _discarded.Add(card);
            card.CancelSelection();
            card.SetDiscard(true);
        }
        _selected.Clear();
    }

    public void ResetAll()
    {
        CancelSelected();
        foreach (Card card in _discarded) 
            card.SetDiscard(false);
        _discarded.Clear();
    }
}
