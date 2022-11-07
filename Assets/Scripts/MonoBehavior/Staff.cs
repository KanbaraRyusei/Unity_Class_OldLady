using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField]
    [Header("参加者の人数（プレイヤーも含める）")]
    private int _participantNum;

    [SerializeField]
    [Header("参加者のプレハブ")]
    private GameObject _prefab;

    [SerializeField]
    [Header("プレイヤーのプレハブ")]
    private GameObject _player;

    [SerializeField]
    [Header("適当な名前")]
    private string[] _names;

    public void GenerateParticipant()
    {
        var player = Instantiate(_player);
        player.GetComponent<ParticipantBase>().SetData(_names[Random.Range(0, _names.Length)], 0);

        for (int i = 1; i < _participantNum; i++)
        {
            var participant = Instantiate(_prefab);
            participant.GetComponent<ParticipantBase>().SetData(_names[Random.Range(0, _names.Length)], i);
        }
    }
}
