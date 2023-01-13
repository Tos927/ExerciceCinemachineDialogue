using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogConfig2 : MonoBehaviour
{
    [System.Serializable]
    public struct SentenceConfig
    {
        public enum POSTION
        {
            LEFT,
            RIGHT
        }
        public POSTION postion;
        [TextArea]public string sentence;
        public AudioClip audioClip;
    }

    [Header("PERSO")]
    public string nameLeft;
    public Sprite spriteLeft;
    public string nameRight;
    public Sprite spriteRight;

    [Header("SENTENCES")]
    public List<SentenceConfig> sentenceConfig = new List<SentenceConfig>();

}
