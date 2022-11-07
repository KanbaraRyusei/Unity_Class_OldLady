using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public int Number => _number;
    public Suits Suit => _suit;

    private int _number;

    private Suits _suit;

    public Card(int number, Suits suits)
    {
        _number = number;
        _suit = suits;
    }
}
