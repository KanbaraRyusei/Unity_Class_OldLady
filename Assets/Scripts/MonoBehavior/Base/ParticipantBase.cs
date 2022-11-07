using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class ParticipantBase : MonoBehaviour
{
    public IReadOnlyList<Card> Hands => _hands;
    public string Name => _name;
    public int Index => _index;

    private List<Card> _hands = new List<Card>();
    private string _name;
    private int _index;

    public void SetData(string name, int index)
    {
        _name = name;
        _index = index;
        Debug.Log(_name + _index);
    }

    public void AddHand(Card card)
    {
        _hands.Add(card);
    }

    public void RemoveHand(Card card)
    {
        _hands.Remove(card);
    }

    public void HandCheck()
    {
        if(_hands.Count == 0)
        {
            Debug.Log("Win" + _name);
        }
        SameHandCheck();
    }

    private void SameHandCheck()
    {
        List<Card> tempCards = new List<Card>();
        for (int i = 0; i < _hands.Count; i++)
        {
            for (int j = 0; j < _hands.Count; j++)
            {
                if (_hands[i].Number == _hands[j].Number)
                {
                    if (!_hands.Contains(_hands[i]))
                    {
                        tempCards.Add(_hands[i]);
                    }
                    if (!_hands.Contains(_hands[j]))
                    {
                        tempCards.Add(_hands[j]);
                    }
                }
            }
        }
        tempCards.OrderBy(x => x.Number);
        for (int i = 0; i < tempCards.Count; i += 2)
        {
            DisposeHand(tempCards[i], tempCards[i + 1]);
        }
    }

    private void DisposeHand(Card card1, Card card2)
    {
        _hands.Remove(card1);
        _hands.Remove(card2);
        Debug.Log(card1 + "‚Æ" + card2 + "‚ðŽÌ‚Ä‚Ü‚µ‚½");
    }

    public abstract void GetOtherHand();
}
