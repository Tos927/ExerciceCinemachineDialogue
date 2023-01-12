using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeakerDataBase", menuName ="Database/Speaker", order = 1)]
public class SpeakerDataBase : ScriptableObject
{
    public List<SpeakerData> speakerDatas = new();
}
