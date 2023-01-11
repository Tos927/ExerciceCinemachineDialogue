using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogConfig : MonoBehaviour
{
    [System.Serializable]
    public struct SentenceConfig
    {
        public enum POSITION
        {
            LEFT,
            RIGHT
        }
        public POSITION position;
        [TextArea] public string sentence;
        public AudioClip audioClip;
    }

    [Header("PERSO")]
    public string nameLeft;
    public Sprite spriteLeft;
    public string nameRight;
    public Sprite spriteRight;

    [Header("SENTENCES")]
    public List<SentenceConfig> sentenceList = new List<SentenceConfig>();
}
