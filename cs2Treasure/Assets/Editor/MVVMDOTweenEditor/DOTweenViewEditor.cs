using MVVM;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DOTweenView))]
public class DOTweenViewEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var targetCs = (DOTweenView)target;

        targetCs.ControlChild = EditorGUILayout.Toggle("Control Child", targetCs.ControlChild);

        if (GUILayout.Button("PlayForward"))
        {
            var tweens = targetCs.ControlChild ? targetCs.GetComponentsInChildren<DOTweenAnimation>() : targetCs.GetComponents<DOTweenAnimation>();
            targetCs.PlayForward(tweens);
        }

        if (GUILayout.Button("PlayBackwards"))
        {
            var tweens = targetCs.ControlChild ? targetCs.GetComponentsInChildren<DOTweenAnimation>() : targetCs.GetComponents<DOTweenAnimation>();
            targetCs.PlayBackwards(tweens);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(targetCs);
        }
    }
}
