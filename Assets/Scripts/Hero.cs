using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // скорость движения
    [SerializeField] private float jumpForce = 7f; // сила прыжка
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private int extraJumps;
    public int extraJumpsValue;
    public GameObject rulesMenuUI;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Castle" && SceneManager.GetActiveScene().buildIndex != 8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.gameObject.name == "Castle" && SceneManager.GetActiveScene().buildIndex == 8)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //CheckGround();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        //if (isGrounded && Input.GetButtonDown("Jump"))
        //    Jump();

        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            Jump();
            extraJumps--;
        }

        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded)
        {
            Jump();
        }
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    public void Rules(Collision2D collision)
    {
        if (collision.gameObject.name == "Rules")
        {
            rulesMenuUI.SetActive(true);
        }
    }
}
