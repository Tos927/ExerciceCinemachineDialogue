using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static DialogConfig;
using static DialogConfig.SpeakerConfig;

[CustomEditor(typeof(DialogConfig))]
[CanEditMultipleObjects]
public class DialogConfigEditor : Editor
{
    private DialogConfig _source;

    private GUIStyle _titleStyle;

    private void OnEnable()
    {
        _source = target as DialogConfig;
        
    }

    public override void OnInspectorGUI()
    {
        InitStyle();
        DrawSpeakersPanel();
    }

    private void DrawSpeakersPanel()
    {
        EditorGUILayout.BeginVertical("box");

        DrawHeader();
        DrawBody();
        DrawFooter();

        EditorGUILayout.EndVertical();

        void DrawHeader()
        {

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Speakers", _titleStyle);
            if (GUILayout.Button(new GUIContent("X", "Clear all speakers"), GUILayout.Width(30)))
            {
                Debug.Log("Clear all speakers");
            }

            EditorGUILayout.EndHorizontal();
        }
        void DrawBody()
        {
            if (_source.speakers.Count != 0)
            {
                for (int i = 0; i < _source.speakers.Count; i++)
                {
                    SpeakerConfig config = _source.speakers[i];

                    config.SetPosition((SpeakerConfig.POSITION)EditorGUILayout.EnumPopup(config.position));

                    _source.speakers[i] = config;
                }
            }
        }
        void DrawFooter()
        {
            if (GUILayout.Button(new GUIContent("Add new speaker", "")))
            {
                _source.speakers.Add(new DialogConfig.SpeakerConfig());
            }
        }
    }

    private void InitStyle()
    {
        #region SpeakersLabel
        _titleStyle = GUI.skin.label;
        _titleStyle.alignment = TextAnchor.MiddleCenter;
        _titleStyle.fontStyle = FontStyle.Bold;
        _titleStyle.fontSize = 15;
        #endregion
    }
}
