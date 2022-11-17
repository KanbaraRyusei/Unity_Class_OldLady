using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ParticipantBase
{
    public override void GetOtherHand()
    {
        Debug.Log("I am Enemy");
        base.GetOtherHand();
        Debug.Log("I'm Enemy");
        NextTurn();
    }
}
