using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private UIManager ui;
    [SerializeField] private HealthBar healthBar;
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lastMovement = new Vector2(0, -1);
    private Animator animator;
    private int maxHealth = 50;
    private int currentHealth;
    private bool hasBombs = true;
    private int bombs = 3;
    private int score;
    [SerializeField] int hiScore;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        score = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        hiScore = 1000;

    }

    void Update()
    {
        if (InputSystem.actions["Attack"].IsPressed())
        {
            InputSystem.actions["Attack"].Reset();
            GameObject proj = Instantiate(bullet, transform.position, Quaternion.identity);
            Projectile sb = proj.GetComponent<Projectile>();
            sb.Shoot(new Vector2((lastMovement.x), lastMovement.y), 300);
        }
    }
    
    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

    // Handles the animator
    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("IsWalking", true);
        if (context.canceled)
        {
            animator.SetBool("IsWalking", false);
            animator.SetFloat("LastMoveX", movement.x);
            animator.SetFloat("LastMoveY", movement.y);
        }
        movement = context.ReadValue<Vector2>();
        if (movement.x != 0 || movement.y != 0)
        {
            lastMovement = movement;
        }
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
    }
    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "GreenZombie")
        {
            TakeDamage(1);
        }
        else if (other.gameObject.tag == "PinkZombie")
        {
            TakeDamage(2);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth--;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            SceneManager.LoadScene("game");
        }
    }

    public void ScoreUpdate()
    {
        score += 100;
        ui.SetScore(score);
        if (score > hiScore)
        {
            ui.SetHiScore(score);
        }
       
    }
}
