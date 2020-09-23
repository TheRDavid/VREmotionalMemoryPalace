using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileOutput : MonoBehaviour
{
    // Start is called before the first frame update
    string txt = "1:\n";
    void Start()
    {

        string[] currentNames = Directory.GetFiles("/storage/emulated/0/Download/mediaUpload");

        foreach(string s in currentNames)
        {
            txt += "\n" + s;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
