using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField]
    [Header("スートの数")]
    private int _suitNum = 4;

    [SerializeField]
    [Header("1スート当たりの枚数")]
    private int _cardNum = 13;

    [SerializeField]
    [Header("ジョーカーの枚数")]
    private int _joker = 1;

    public void Generate()
    {
        Suits suit = Suits.Spade;

        for(int i = 0; i < _suitNum; i++)
        {
            for (int j = 1; j <= _cardNum; j++)// カードの数に0はないため合わせる
            {
                var card = new Card(j, suit);
                CardManager.Register(card);
            }
            suit++;
        }

        var joker = new Card(0, Suits.Joker);
        CardManager.Register(joker);

        for (int i = 0; i < CardManager.Cards.Count; i++)
        {
            Debug.Log(CardManager.Cards[i].Suit + " " + CardManager.Cards[i].Number);
        }
    }

    public void Delete()
    {
        for(int i = 0; i < CardManager.Cards.Count; i++)
        {
            CardManager.Release(CardManager.Cards[i]);
        }

        if(CardManager.Cards.Count > 0)
        {
            Delete();
        }
    }

    public void Shuffle()
    {
        CardManager.Shuffle();

        for(int i = 0; i < CardManager.Cards.Count; i++)
        {
            Debug.Log(CardManager.Cards[i].Suit + " " + CardManager.Cards[i].Number);
        }
    }

    public void Distribute()// カードを配る
    {
        int num = CardManager.Cards.Count / ParticipantManager.Participants.Count;
        int index = 0;

        for(int i = 0; i < ParticipantManager.Participants.Count; i++)
        {
            for(int j = 0; j < num; j++)
            {
                ParticipantManager.Participants[i].AddHand(CardManager.Cards[j]);
                index++;
            }
        }

        if(CardManager.Cards.Count > index)
        {
            for(int i = 0; i < CardManager.Cards.Count - index; i++)
            {
                ParticipantManager.Participants[i].AddHand(CardManager.Cards[index + i]);
            }
        }
    }
}
