using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    private float length;
    private float startPos;
    public GameObject cam;
    public float parallaxEffector;

    void Start() {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        float temp = cam.transform.position.x * (1- parallaxEffector);
        float distance = cam.transform.position.x * parallaxEffector;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length) {
            startPos += length;
        }
        else if (temp < startPos - length) {
            startPos -= length;
        }

    }
}
