using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

    #region EDITOR

    public override void OnInspectorGUI()
    {
        InitStyle();
        DrawSpeakersDataBasePanel();

        EditorGUILayout.Space();

        DrawSpeakersPanel();
    }
    private void DrawSpeakersDataBasePanel()
    {
        EditorGUILayout.BeginVertical("box");

        DrawHeader();
        DrawBody();
        DrawFooter();

        EditorGUILayout.EndVertical();

        void DrawHeader()
        {

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Speakers Database", _titleStyle);
            if (GUILayout.Button(new GUIContent("X", "Clear all Databases"), GUILayout.Width(30)))
            {
                if (EditorUtility.DisplayDialog("Delete all Database ?", "Do you want delete all Database ?", "Yes", "No"))
                    _source.speakersDatabases.Clear();
            }

            EditorGUILayout.EndHorizontal();

        }
        void DrawBody()
        {
            if (_source.speakersDatabases.Count != 0)
            {
                for (int i = 0; i < _source.speakersDatabases.Count; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    _source.speakersDatabases[i] = EditorGUILayout.ObjectField(_source.speakersDatabases[i], typeof(SpeakerDataBase), false) as SpeakerDataBase;
                    
                    if (GUILayout.Button(new GUIContent("X", "Remove speakers"), GUILayout.Width(30)))
                    {
                        _source.speakersDatabases.RemoveAt(i);
                        break;
                    }

                    EditorGUILayout.EndHorizontal();
                }
            }

        }
        void DrawFooter()
        {
            if (GUILayout.Button(new GUIContent("Add new Database", "")))
            {
                _source.speakersDatabases.Add(new());
            }
        }

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
                if(EditorUtility.DisplayDialog("Delete all speakers ?", "Do you want delete all speakers ?", "Yes", "No"))
                    _source.speakers.Clear();
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

                    EditorGUILayout.BeginHorizontal();
                    if (_source.speakersDatabases.Count != 0)
                    {
                        if (_source.speakersDatabases.Count > 1)
                        {
                            List<string> allDatabaseLabel = new();
                            foreach (SpeakerDataBase sd in _source.speakersDatabases)
                                allDatabaseLabel.Add(sd.name);

                            int idDatabase = _source.speakersDatabases.FindIndex(x => x == config.dataBase);
                            idDatabase = EditorGUILayout.Popup(idDatabase, allDatabaseLabel.ToArray());

                            config.dataBase = _source.speakersDatabases[idDatabase];
                        }
                        else
                            config.dataBase = _source.speakersDatabases.First();
                    }

                    EditorGUILayout.Popup(0, new string[] { "0", "1" });

                    config.SetPosition((SpeakerConfig.POSITION)EditorGUILayout.EnumPopup(config.position));

                    if (GUILayout.Button(new GUIContent("X", "Remove speakers"), GUILayout.Width(30)))
                    {
                        _source.speakers.RemoveAt(i);
                        break;
                    }

                    EditorGUILayout.EndHorizontal();

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


    #endregion
    #region STYLE

    private void InitStyle()
    {
        #region SpeakersLabel
        _titleStyle = GUI.skin.label;
        _titleStyle.alignment = TextAnchor.MiddleCenter;
        _titleStyle.fontStyle = FontStyle.Bold;
        _titleStyle.fontSize = 15;
        #endregion
    }

    #endregion
}
