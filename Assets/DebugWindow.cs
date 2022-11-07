using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWindow : MonoBehaviour
{
    TextMesh textMesh;
    int len = 300;
    float offsety = 1.0f;
    float offsetz = 2.0f;

    // Use this for initialization
    void Start()
    {
        textMesh = gameObject.GetComponentInChildren<TextMesh>();
    }

    void OnEnable()
    {
        Application.logMessageReceived += LogMessage;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= LogMessage;
    }

    public void LogMessage(string message, string stackTrace, LogType type)
    {
        if (message.Contains("RES"))
        {
            if (!textMesh.text.Contains(message))
            {
                textMesh.text += message + "\n";
            }
        }
        if (textMesh.text.Length > len)
        {
            len *=2;
            offsety += 0.8f;
            offsetz += 0.3f;
            textMesh.transform.localPosition = new Vector3(-1.8f, offsety, offsetz);
        }
    }
}
