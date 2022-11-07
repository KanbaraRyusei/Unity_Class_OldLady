using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField]
    [Header("�Q���҂̐l���i�v���C���[���܂߂�j")]
    private int _participantNum;

    [SerializeField]
    [Header("�Q���҂̃v���n�u")]
    private GameObject _prefab;

    [SerializeField]
    [Header("�v���C���[�̃v���n�u")]
    private GameObject _player;

    [SerializeField]
    [Header("�K���Ȗ��O")]
    private string[] _names;

    private GameObject[] _participants;

    public void GenerateParticipant()
    {
        _participants = new GameObject[_participantNum];
        var player = Instantiate(_player);
        player.GetComponent<ParticipantBase>().SetData(_names[Random.Range(0, _names.Length)], 0);
        _participants[0] = player;

        for (int i = 1; i < _participantNum; i++)
        {
            var participant = Instantiate(_prefab);
            participant.GetComponent<ParticipantBase>().SetData(_names[Random.Range(0, _names.Length)], i);
            _participants[i] = participant;
        }
    }

    public void DeleteParticipant()
    {
        if(_participants == null)
        {
            Debug.LogError("�폜�Ώۂ�������܂���");
            return;
        }
        for(int i = 0; i < _participants.Length; i++)
        {
            DestroyImmediate(_participants[i]);
        }
        _participants = null;
        Debug.Log("�폜���܂���");
    }
}
