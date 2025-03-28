using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTextureDefault;

    [SerializeField] private Vector2 clickposition = Vector2.zero;


    void Start()
    {
        Cursor.SetCursor(cursorTextureDefault, clickposition, CursorMode.Auto);
    }


}
