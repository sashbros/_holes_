using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairScript : MonoBehaviour
{
    public int whatToDo; //1 meaning crosshair 0 meaning cursor
    void Start() {
        if (whatToDo == 1)
            Cursor.visible = false;
        else {
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update() {
        if (whatToDo == 1) {
            Vector2 curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = curPos;
        }
    }
}
