using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursorTexture;
    private void Start()
    {
        // Calculate the center of the texture
        Vector2 hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);

        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
}
