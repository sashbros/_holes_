using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private Transform playerTransform;
    private Vector2 target;
    public GameObject killEnemyEffect;
    private int flag=0;

    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(playerTransform.position.x, playerTransform.position.y);
    }
    void Update() {
        Vector3 difference = transform.position - playerTransform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (flag==0) {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
            flag=1;

        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y) {
            DestroyEnemyBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            DestroyEnemyBullet();
            Instantiate(killEnemyEffect, other.transform.position, Quaternion.LookRotation(transform.up));
            other.gameObject.SetActive(false);
            GameObject.Find("Pistol").SetActive(false);
            GameObject.Find("GameManager").GetComponent<gameManager>().RestartCurrentScene();
            FindObjectOfType<audioManager>().Play("Blood");
        }
        if (other.CompareTag("Ground")) {
            DestroyEnemyBullet();
        }
    }

    void DestroyEnemyBullet() {
        Destroy(gameObject);
    }

    
}
