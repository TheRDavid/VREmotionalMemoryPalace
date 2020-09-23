using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ImageRoll : MonoBehaviour
{
    public Renderer rend;
    float elapsed = 0f;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        string directoryPath = "/storage/emulated/0/Download/mediaUpload";
        if (!Directory.Exists(directoryPath))
        {
            //if it doesn't, create it
            Directory.CreateDirectory(directoryPath);

        }
    }

    bool IsFileAvailable(FileInfo file)
    {
        FileStream stream = null;

        try
        {
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException)
        {

            HudDeb.Log("Not Available");
            return false;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }

        HudDeb.Log("Available");
        return true;
    }

    // Update is called once per frame
    void Update()
    {

        elapsed += Time.deltaTime;

        if (elapsed >= 0.5f)
        {
            elapsed %= 0.5f;

            UpdateTexture();
            index++;
        }
        transform.RotateAround(transform.position, transform.up, 1f);


    }

    void UpdateTexture()
    {
        string[] currentPaths = Directory.GetFiles("/storage/emulated/0/Download/mediaUpload");
        if (index == currentPaths.Count())
        {
            index = 0;
        }
        if (currentPaths[index] == null) return;
        string path = currentPaths[index];
        byte[] byteArray = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(8, 8);
        texture.LoadImage(byteArray);
        rend.material.mainTexture = texture;


    }

}
