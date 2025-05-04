using UnityEngine;
using System.Collections.Generic;

public class GameCardsStateControl : MonoBehaviour
{
    private const string ANIMATION_OPTIONS = "start_options";
    private const string ANIMATION_GAME_36 = "start_game_36";
    private const string ANIMATION_GAME_52 = "start_game_52";

    private List<Card> _selected = new();
    private List<Card> _onEnemy = new();
    private List<Card> _onMe = new();
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

    //Home button
    public void ResetAll()
    {
        if (_selected.Count > 0)
        {
            foreach (Card card in _selected)
                card.SetSelected(false);
            _selected.Clear();
        }

        if (_onMe.Count > 0)
        {
            foreach (Card card in _onMe)
                card.SetToMe(false);
            _onMe.Clear();
        }

        if (_onEnemy.Count > 0)
        {
            foreach (Card card in _onEnemy)
                card.SetToEnemy(false);
            _onEnemy.Clear();
        }

        if (_discarded.Count > 0)
        {
            foreach (Card card in _discarded)
                card.SetDiscard(false);
            _discarded.Clear();
        }
    }

    // ToMe button
    public void ToMeSelected(AudioSource audioSource)
    {
        if (_selected.Count > 0)
        {
            audioSource.Play();
            foreach (Card card in _selected)
            {
                _onMe.Add(card);
                card.SetToMe(true);
            }
            _selected.Clear();
        }
    }

    // ToEnemy button
    public void ToEnemySelected(AudioSource audioSource)
    {
        if (_selected.Count > 0)
        {
            audioSource.Play();
            foreach (Card card in _selected)
            {
                _onEnemy.Add(card);
                card.SetToEnemy(true);
            }
        }
        _selected.Clear();
    }

    //Discard button
    public void DiscardSelected(AudioSource audioSource)
    {
        if (_selected.Count > 0)
        {
            audioSource.Play();
            foreach (Card card in _selected)
            {
                _discarded.Add(card);
                card.SetDiscard(true);
            }
        }
    }
}
