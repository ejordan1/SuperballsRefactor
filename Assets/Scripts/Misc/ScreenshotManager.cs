﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    public static ScreenshotManager st;

    public List<Sprite> screenshots;

    Camera cam;

    void Awake()
    {
        st = this;
        cam = GetComponent<Camera>();
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeScreenshot();
        //}
    }

    public void TakeScreenshot()
    {
        cam = GetComponent<Camera>();
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam.targetTexture = renderTexture;
        cam.Render();
        cam.targetTexture = null;

        RenderTexture.active = renderTexture;
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();
        RenderTexture.active = null;

        byte[] bytes = screenshot.EncodeToPNG();
        Destroy(screenshot);

        DirectoryInfo screenshotsDirectory = new DirectoryInfo(Application.dataPath + "/Resources/Screenshots/");
        FileInfo[] dirInfo = screenshotsDirectory.GetFiles();
        int number = 0;
        foreach (var item in dirInfo)
        {
            number++;
        }

        string name = "Screenshot" + number + ".png";
        File.WriteAllBytes(Application.dataPath + "/Resources/Screenshots/" + name, bytes);

        AssetDatabase.Refresh();

        //// DISPLAYS THE SCREENSHOT ON AN IMAGE
        //var t2d = AssetDatabase.LoadAssetAtPath("Assets/Resources/Screenshots/" + name, typeof(Texture2D)) as Texture2D;
        //Sprite spr = Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), new Vector2(.5f, .5f));
        //CanvasManager.st.DisplayScreenshot(spr as Sprite);
    }

    // TODO: Make screenshot system work in built mode.
}