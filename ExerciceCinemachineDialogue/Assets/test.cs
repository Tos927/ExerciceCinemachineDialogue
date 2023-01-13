using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        Sirenix.Utilities.Editor.GUIHelper.RequestRepaint();
        return Color.HSVToRGB(Mathf.Cos((float)UnityEditor.EditorApplication.timeSinceStartup + 1) * 0.5f + .5f, 1, 1);
    }
}
