using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParticipantManager
{
    public static IReadOnlyList<ParticipantBase> Participants => _participants;
    public static IReadOnlyList<ParticipantBase> Winners => _winners;

    private static List<ParticipantBase> _participants = new List<ParticipantBase>();

    private static List<ParticipantBase> _winners = new List<ParticipantBase>();

    public static void Register(ParticipantBase participantBase)
    {
        _participants.Add(participantBase);
        Debug.Log(participantBase.Name);
    }

    public static void Release(ParticipantBase participantBase)
    {
        _participants.Remove(participantBase);
    }

    public static void Win(ParticipantBase participantBase)
    {
        _winners.Add(participantBase);
    }
}
