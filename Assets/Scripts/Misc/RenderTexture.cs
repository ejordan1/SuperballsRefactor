using UnityEngine;
using System.Collections.Generic;


public class Example : MonoBehaviour
{
    Camera camera;

    public List<RenderTexture> renderTexters;

    public void Start()
    {
        camera = GetComponent<Camera>();
        camera.enabled = false;

        
    }

    public void Update()
    {
        RTImage(camera);
        //Debug.Log("F");
    }

    // Take a "screenshot" of a camera's Render Texture.
    Texture2D RTImage(Camera camera)
    {
        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.
        var currentRT = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;
        //Debug.Log(camera.targetTexture.width);
        // Render the camera's view.
        camera.Render();
        //Debug.Log(camera);
        // Make a new texture and read the active Render Texture into it.
        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();

        // Replace the original active Render Texture.
        RenderTexture.active = currentRT;

        //Graphics.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), camera.targetTexture);

        return image;
    }
}

