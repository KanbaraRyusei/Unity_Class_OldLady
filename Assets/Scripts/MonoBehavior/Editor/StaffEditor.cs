using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Staff))]
public class StaffEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Staff staff = target as Staff;

        if(GUILayout.Button("GenerateParticipant"))
        {
            staff.GenerateParticipant();
        }

        if(GUILayout.Button("DeleteParticipant"))
        {
            staff.DeleteParticipant();
        }
    }
}
