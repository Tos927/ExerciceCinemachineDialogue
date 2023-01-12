using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogConfig : MonoBehaviour
{
    [System.Serializable]
    public struct SpeakerConfig
    {
        public enum POSITION
        {
            LEFT,
            MIDDLE,
            RIGHT
        }
        public POSITION position;
        public SpeakerDataBase dataBase;
        public SpeakerData data;

        public void SetPosition(POSITION newPosition)
        {
            position = newPosition;
        }
    }

    public List<SpeakerConfig> speakers = new();

    [System.Serializable]
    public struct SentenceConfig
    {
        [TextArea] public string sentence;
        public AudioClip audioClip;
    }

    public List<SpeakerDataBase> speakersDatabases = new();

    /*[Header("PERSO")]
    public string nameLeft;
    public Sprite spriteLeft;
    public string nameRight;
    public Sprite spriteRight;*/

    [Header("SENTENCES")]
    public List<SentenceConfig> sentenceList = new();
}
