using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public ParticleSystem dustPS;

    public float speed;
    [HideInInspector]
    public float input;
    private Rigidbody2D rb;

    [HideInInspector]
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //jump code
    public float jumpForce;

    //better jump code
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;


    public timeManager timeManager;

    public GameObject killEnemyEffect;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        input = Input.GetAxis("Horizontal");
        if (input < 0) {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            CreateDust();
        }
        else if (input > 0) {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            CreateDust();
        }
        if (input == 0) {
            gameObject.GetComponent<Animator>().SetBool("isRunning", false);
        }
        else {
            gameObject.GetComponent<Animator>().SetBool("isRunning", true);
        }
        // input = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

    }

    void Update() {

        if (transform.position.y < -10f) {
            GameObject.Find("GameManager").GetComponent<gameManager>().RestartCurrentScene();
        }

        //jump code
        if(Input.GetButtonDown("Jump") && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
            timeManager.doSlowMotion();
            CreateDust();
        }
        
        //better Jump Code
        if(rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CreateDust() {
        dustPS.Play();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Apple")) {
            other.gameObject.SetActive(false);
            FindObjectOfType<audioManager>().Play("Spinach");
            GameObject.Find("GameManager").GetComponent<gameManager>().AdvanceToNextScene();
        }
        if (other.gameObject.CompareTag("Spikes")) {
            gameObject.SetActive(false);
            if (GameObject.Find("Pistol") != null)
                GameObject.Find("Pistol").SetActive(false);
            if (GameObject.Find("GameManager") != null)
                GameObject.Find("GameManager").GetComponent<gameManager>().RestartCurrentScene();
            Instantiate(killEnemyEffect, transform.position, Quaternion.LookRotation(transform.up));
            FindObjectOfType<audioManager>().Play("Blood");
        }
    }
}
