using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShellScript : MonoBehaviour
{
    public float shellSpeed;

    void Start() {
        
    }

    void Update() {
        if (GameObject.Find("Pistol") != null) {
            int running = GameObject.Find("Pistol").GetComponent<aimShoot>().running;
            if (running == 1) {
                transform.Translate(new Vector2(-1f, 1f) * shellSpeed * Time.deltaTime);
            }
            if (running == -1) {
                transform.Translate(new Vector2(1f, 1f) * shellSpeed * Time.deltaTime);
            }
        }
    }
}
