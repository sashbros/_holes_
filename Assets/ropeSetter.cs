using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeSetter : MonoBehaviour
{
    public spiderRope rope;

    void Start() {
        
    }

    void Update() {
        if (Input.GetMouseButton(1)) {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rope.setStart(worldPos);
        }
    }
}
