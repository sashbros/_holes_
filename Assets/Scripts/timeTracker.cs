using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timeTracker : MonoBehaviour
{
    public static float timeSpent;
    public static timeTracker instance;
    private void Awake() {
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);    
    }

    void Update() {
        if (SceneManager.GetActiveScene().name != "Level13") {
            timeSpent += Time.unscaledDeltaTime;
            timeSpent = (float)Mathf.Round(timeSpent * 100f) / 100f;
            if (GameObject.Find("TimerText") != null) {
                GameObject.Find("TimerText").GetComponent<Text>().text = timeSpent + " secs";
            }
        }
        else {
            if (GameObject.Find("TimerText") != null) {
                GameObject.Find("TimerText").GetComponent<Text>().text = timeSpent + " secs";
            }
        }
        if (SceneManager.GetActiveScene().name == "Level01") {
            ResetTime();
        }
    }
    void ResetTime() {
        timeSpent = 0f;
    }
}
