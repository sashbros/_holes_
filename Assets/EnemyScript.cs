using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject hands;
    public GameObject enemyBullet;
    public Transform player;
    public float maxDistFromPlayer;

    [HideInInspector]
    public bool killed = false;

    void Start() {
        timeBtwShots = startTimeBtwShots;
    }

    void Update() {
        if (Vector2.Distance(transform.position, player.position) < maxDistFromPlayer && 
                                                        GameObject.Find("Player") != null && killed == false) {
            if (timeBtwShots <= 0) {
                Instantiate(enemyBullet, hands.transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;

            }
            else if (timeBtwShots > 0) {
                timeBtwShots-=Time.deltaTime;
            }
        }
    }
}
