using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudDeb : MonoBehaviour
{
    static string text = "Debug:\n";

    public static void Log(string txt)
    {
        text += txt + "\n";
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = text;
    }
}
