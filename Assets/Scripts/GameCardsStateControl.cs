using UnityEngine;
using System.Collections.Generic;

public class GameCardsStateControl : MonoBehaviour
{
    private List<Card> _selected = new();
    private List<Card> _discarded = new();

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

    public void CancelAll()
    {
        foreach (Card card in _selected) card.CancelSelection();
        _selected.Clear();
    }

    public void DiscardAll()
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
        CancelAll();
        foreach (Card card in _discarded) card.SetDiscard(false);
        _discarded.Clear();
    }
}
