using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Dealer))]
public class DealerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Dealer dealer = target as Dealer;

        if(GUILayout.Button("Genarate"))
        {
            dealer.Generate();
        }

        if(GUILayout.Button("Delete"))
        {
            dealer.Delete();
            Debug.Log("çÌèúÇµÇ‹ÇµÇΩ" + CardManager.Cards.Count);
        }

        if(GUILayout.Button("Shuffle"))
        {
            dealer.Shuffle();
        }
    }
}
