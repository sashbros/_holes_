using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairScript : MonoBehaviour
{
    void Start() {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        Vector2 curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = curPos;
    }
}
