using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;

    public float killForce;
    public GameObject killEnemyEffect;

    private void Start() {
        Invoke("DestroyBullet", lifeTime);
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Enemy") && 
                   hitInfo.collider.gameObject.GetComponentInChildren<HingeJoint2D>()) {
                // Debug.Log("ENEMY");
                hitInfo.collider.gameObject.GetComponentInChildren<HingeJoint2D>().enabled = false;
            }
            if (hitInfo.collider.CompareTag("Enemy")) {
                hitInfo.collider.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(transform.up * killForce, hitInfo.collider.transform.position);
                Instantiate(killEnemyEffect, hitInfo.collider.transform.position, Quaternion.LookRotation(transform.up));
            }
            DestroyBullet();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyBullet() {
        Destroy(gameObject);
    }

}
