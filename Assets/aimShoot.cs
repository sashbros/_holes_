using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public Transform gunStartRight;
    public Transform gunStartLeft;
    
    private float timeBtwShots;
    public float startTimeBtwShots;

    public float offset;
    private int running=1;
    void Update() {
        if (player.GetComponent<playerMovement>().input < 0) {
            running = -1;
        }
        else if (player.GetComponent<playerMovement>().input > 0) {
            running = 1;
        }

        //left movement
        if (running == -1) {
            transform.position = player.transform.position - new Vector3(0.5f, 0f, 0f);
            GetComponent<SpriteRenderer>().flipX = true;
            AimShoot(-1);
        }
        //right movement
        else if (running == 1) {
            transform.position = player.transform.position + new Vector3(0.5f, 0f, 0f);
            GetComponent<SpriteRenderer>().flipX = false;
            AimShoot(1);
        }
        
    }
    public void AimShoot(int direction) {
        if (direction == 1) {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            if (timeBtwShots <= 0) {
                if (Input.GetMouseButton(0)) {
                    Instantiate(bullet, gunStartRight.position, transform.rotation * Quaternion.Euler(0f, 0f, -90f));
                    timeBtwShots = startTimeBtwShots;
                }
            }
            else {
                timeBtwShots -= Time.deltaTime;
            }
            
        }
        else if (direction == -1) {
            Vector3 difference = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            if (timeBtwShots <= 0) {
                if (Input.GetMouseButton(0)) {
                    Instantiate(bullet, gunStartLeft.position, transform.rotation * Quaternion.Euler(0f, 0f, 90f));
                    timeBtwShots = startTimeBtwShots;
                }
            }
            else {
                timeBtwShots -= Time.deltaTime;
            }

        }

    }
}
