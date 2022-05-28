using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Texture2D[] cursorImgs;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        //Event e = Event.current;
        //if (e.isKey)
        //{
        //    switch (e.keyCode)
        //    {
        //        case KeyCode.None:
        //            break;
        //        case KeyCode.Alpha1:
        //            Cursor.SetCursor(cursorImgs[1], new Vector2(cursorImgs[1].width/2, cursorImgs[1].height/2), CursorMode.Auto);
        //            break;
        //        case KeyCode.Alpha0:
        //            Cursor.SetCursor(cursorImgs[0], new Vector2(cursorImgs[0].width / 2, cursorImgs[0].height / 2), CursorMode.Auto);
        //            break;
        //    }
        //    Debug.Log("Detected key code: " + e.keyCode);
        //}
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorImgs[1], new Vector2(cursorImgs[1].width / 2, cursorImgs[1].height / 2), CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(cursorImgs[0], new Vector2(cursorImgs[0].width / 2, cursorImgs[0].height / 2), CursorMode.Auto);
    }
}
