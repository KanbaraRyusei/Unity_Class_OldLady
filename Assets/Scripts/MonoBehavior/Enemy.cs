using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ParticipantBase
{
    public override void GetOtherHand()
    {
        base.GetOtherHand();
        NextTurn();
    }
}
