using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParticipantManager
{
    public static IReadOnlyList<ParticipantBase> Participants => _participants;

    private static List<ParticipantBase> _participants;

    public static void Register(ParticipantBase participantBase)
    {
        _participants.Add(participantBase);
    }

    public static void Release(ParticipantBase participantBase)
    {
        _participants.Remove(participantBase);
    }
}
