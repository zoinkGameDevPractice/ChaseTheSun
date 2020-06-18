using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScoreManager))]
public class ScoreManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ScoreManager score = (ScoreManager)target;

        if(GUILayout.Button("Reset High Score"))
        {
            score.ResetHighScore();
        }
    }
}
