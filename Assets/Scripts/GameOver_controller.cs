using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_controller : MonoBehaviour
{
    //public Texture btnTexture;
    public Vector2 offset;
    public Vector2 sizeButton;
    void OnGUI()
    {

        //if (!btnTexture)
        //{
        //    Debug.LogError("Please assign a texture on the inspector");
        //    return;
        //}

        //if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
        //    Debug.Log("Clicked the button with an image");

        if (GUI.Button(new Rect(offset.x, offset.y, 50, 30), "Restart")) {
            Application.LoadLevel("scne");
        }
            
    }
}
