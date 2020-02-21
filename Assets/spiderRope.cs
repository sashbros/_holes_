using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderRope : MonoBehaviour
{
    private LineRenderer line;
    public Material material;
    public Rigidbody2D origin;
    public float lineWidth = 0.1f;

    public float speed = 75f;
    private Vector3 velocity;

    public float pullForce = 50f;
    private bool pull = false;
    private bool update = false;

    public float ropeStayTime = 1f;
    private IEnumerator timer;


    void Start() {
        line = GetComponent<LineRenderer>();
        if (!line) {
            line = gameObject.AddComponent<LineRenderer>();
        }
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.material = material;
    }

    void Update() {
        if (!update) {
            return;
        }
        if (pull) {
            Vector2 dir = (Vector2)transform.position - origin.position;
            dir = dir.normalized;
            origin.AddForce(dir * pullForce);
        }
        else{
            transform.position += velocity * Time.deltaTime;
            float distance = Vector2.Distance(transform.position, origin.position);
            if (distance > 30f) {
                update = false;
                line.SetPosition(0, Vector2.zero);
                line.SetPosition(1, Vector2.zero);
                return;
            }
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, origin.position);
    }

    public void setStart(Vector2 targetPos) {
        Vector2 dir = targetPos - origin.position;
        dir = dir.normalized;
        velocity = dir * speed;
        transform.position = origin.position + dir;
        pull = false;
        update = true;

        if (timer != null) {
            StopCoroutine(timer);
            timer = null;
            Debug.Log("ygiuhjkl");
            origin.gameObject.GetComponent<Animator>().SetTrigger("rotate");
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        velocity = Vector2.zero;
        pull = true;
        timer = reset(ropeStayTime);
        StartCoroutine(timer);
    }

    IEnumerator reset(float delay) {
        yield return new WaitForSeconds(delay);
        update = false;
        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, Vector2.zero);
        // origin.gameObject.GetComponent<Animator>().SetTrigger("rotate");

    }
}
