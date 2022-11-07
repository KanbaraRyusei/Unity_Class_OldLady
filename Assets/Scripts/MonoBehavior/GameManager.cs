using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Dealer _dealer;

    private void Start()
    {
        _dealer.Shuffle();
        _dealer.Distribute();
        CheckHand();
        Turn(ParticipantManager.Participants[0]);
    }

    private void CheckHand()
    {
        for(int i = 0; i < ParticipantManager.Participants.Count; i++)
        {
            ParticipantManager.Participants[i].HandCheck();
        }
    }

    private void Turn(ParticipantBase participant)
    {
        participant.GetOtherHand();
    }
}
