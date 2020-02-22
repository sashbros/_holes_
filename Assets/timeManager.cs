using UnityEngine;

public class timeManager : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;

    private void Update() {
        Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        if (Time.timeScale == 1.0f) {
            Time.fixedDeltaTime = Time.deltaTime;
            GameObject.Find("SpiderRope").GetComponent<spiderRope>().pullForce = 200f;
        }
    }

    public void doSlowMotion() {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        GameObject.Find("SpiderRope").GetComponent<spiderRope>().pullForce = 700f;
    }
}
