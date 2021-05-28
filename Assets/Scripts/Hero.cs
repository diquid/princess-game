using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 7f;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private int extraJumps;
    public int extraJumpsValue;
    public GameObject rulesMenuUI;
    public GameObject DieMenuUI;

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
        if (collision.gameObject.name == "Rules")
        {
            rulesMenuUI.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        
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

    public void Die()
    {
        DieMenuUI.SetActive(true);
    }
}
