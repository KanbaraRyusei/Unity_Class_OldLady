using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ParticipantBase : MonoBehaviour
{
    public IReadOnlyList<Card> Hands => _hands;
    public string Name => _name;
    public int Index => _index;

    protected List<Card> _hands = new List<Card>();
    protected string _name;
    protected int _index;

    public void SetData(string name, int index)
    {
        _name = name;
        _index = index;
        Debug.Log(_name + _index);
    }

    public void AddHand(Card card)
    {
        if(_hands.Contains(card))
        {
            Debug.LogError("d•¡‚µ‚Ä‚¢‚Ü‚·" + card.Suit + " " + card.Number);
            return;
        }
        _hands.Add(card);
        Debug.Log("Add" + card.Suit + " " + card.Number + " " + _name);
        HandCheck();
    }

    public void RemoveHand(Card card)
    {
        _hands.Remove(card);
        Debug.Log("Remove" + card.Suit + " " + card.Number + " " + _name);
        WinCheck();
    }

    public void HandCheck()
    {
        SameHandCheck();
        WinCheck();
    }

    public void WinCheck()
    {
        if (_hands.Count == 0)
        {
            Debug.Log("Win" + _name + _hands.Count);
            ParticipantManager.Win(this);
        }
    }

    protected void SameHandCheck()
    {
        List<Card> tempCards = new List<Card>();
        for (int i = 0; i < _hands.Count; i++)
        {
            for (int j = 0; j < _hands.Count; j++)
            {
                if (_hands[i].Number == _hands[j].Number && _hands[i] != _hands[j])
                {
                    Debug.LogWarning("SameNumber" +
                        _hands[i].Suit + " " + _hands[i].Number + " " +
                        _hands[j].Suit + " " + _hands[j].Number + " " + i + " " + j);
                    if (!tempCards.Contains(_hands[i]))
                    {
                        tempCards.Add(_hands[i]);
                    }
                    if (!tempCards.Contains(_hands[j]))
                    {
                        tempCards.Add(_hands[j]);
                    }
                    Debug.LogWarning("Same" + tempCards.Count);
                }
            }
        }
        tempCards.OrderBy(x => x.Number);
        Debug.Log("èD®—Š®—¹");
        if(tempCards.Count % 2 != 0)
        {
            return;
        }
        for (int i = 0; i < tempCards.Count; i += 2)
        {
            DisposeHand(tempCards[i], tempCards[i + 1]);
        }
    }

    protected void DisposeHand(Card card1, Card card2)
    {
        Debug.LogError("Dispose");
        RemoveHand(card1);
        RemoveHand(card2);
        Debug.LogError(_name + "‚ª" + card1.Suit + " " + card1.Number + "‚Æ" + card2.Suit + " " + card2.Number + "‚ğÌ‚Ä‚Ü‚µ‚½");
    }

    public virtual void GetOtherHand()
    {
        if (ParticipantManager.Participants.Count > _index + 1)
        {
            Card card = ParticipantManager.Participants[_index + 1]
                .Hands[Random.Range(0, ParticipantManager.Participants[_index + 1].Hands.Count)];

            ParticipantManager.Participants[_index + 1].RemoveHand(card);
            AddHand(card);
        }
        else
        {
            Card card = ParticipantManager.Participants[0]
                .Hands[Random.Range(0, ParticipantManager.Participants[0].Hands.Count)];

            ParticipantManager.Participants[0]
                .RemoveHand(card);

            AddHand(card);
        }
    }

    public void NextTurn()
    {
        GameManager.Instance.NextTurn(_index);
    }
}
