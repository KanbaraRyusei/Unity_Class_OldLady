using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public static class CardManager
{
    public static IReadOnlyList<Card> Cards => _cards;

    private static List<Card> _cards = new List<Card>();

    public static void Register(Card card)
    {
        if(_cards.Contains(card))
        {
            Debug.LogError("“¯‚¶ƒJ[ƒh‚ª•¡”¶¬‚³‚ê‚Ä‚¢‚Ü‚·");
            return;
        }
        _cards.Add(card);
    }

    public static void Release(Card card)
    {
        _cards.Remove(card);
    }

    public static void Shuffle()
    {
        _cards = _cards.OrderBy(_ => Guid.NewGuid()).ToList();
    }
}
