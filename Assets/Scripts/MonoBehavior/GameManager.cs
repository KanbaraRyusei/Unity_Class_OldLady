using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    Dealer _dealer;

    [SerializeField]
    Staff _staff;

    [SerializeField]
    int _waitTime;

    private async void Start()
    {
        _staff.DeleteParticipant();
        _staff.GenerateParticipant();
        _dealer.Delete();
        _dealer.Generate();
        _dealer.Shuffle();
        _dealer.Distribute();
        for (int i = 0; i < ParticipantManager.Participants.Count; i++)
        {
            Debug.Log(ParticipantManager.Participants[i].Name + ParticipantManager.Participants[i].Hands.Count);
        }
        CheckHand();
        await UniTask.Delay(_waitTime);
        Debug.Log(ParticipantManager.Participants.Count);
        NextTurn(0);
    }

    public void NextTurn(int index)
    {
        if (ParticipantManager.Winners.Count > ParticipantManager.Participants.Count - 2)// 最後の一人までやる
        {
            Debug.LogError("End Winner is " + ParticipantManager.Winners[0].Name);
            return;
        }

        if (index + 1 == ParticipantManager.Participants.Count)
        {
            Debug.Log(ParticipantManager.Participants[0].Name + "のターン");
            for (int i = 0; i < ParticipantManager.Participants[0].Hands.Count; i++)
            {
                Debug.Log(ParticipantManager.Participants[0].Hands[i].Suit
                    + " " + ParticipantManager.Participants[0].Hands[i].Number);
            }

            ParticipantManager.Participants[0].GetOtherHand();
        }
        else
        {
            Debug.Log(ParticipantManager.Participants[index].Name + "のターン");
            for (int i = 0; i < ParticipantManager.Participants[index].Hands.Count; i++)
            {
                Debug.Log(ParticipantManager.Participants[index].Hands[i].Suit
                    + " " + ParticipantManager.Participants[index].Hands[i].Number);
            }
            ParticipantManager.Participants[index + 1].GetOtherHand();
        }
    }

    private void CheckHand()
    {
        for (int i = 0; i < ParticipantManager.Participants.Count; i++)
        {
            ParticipantManager.Participants[i].HandCheck();
        }
    }
}
