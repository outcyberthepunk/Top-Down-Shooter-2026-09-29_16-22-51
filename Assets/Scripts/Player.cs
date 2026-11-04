using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bomb;
    [SerializeField] private HealthBar healthBar;
    public GameManager gm;
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lastMovement = new Vector2(0, -1);
    private Animator animator;
    private int maxHealth = 50;
    private int currentHealth;
    private bool hasBombs = true;
    private int bombs = 5;
    private Enemy enemy;
    public AudioSource audio;
    public AudioClip shootSFX;
    public UIManager ui;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        audio = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (InputSystem.actions["Attack"].IsPressed())
        {
            InputSystem.actions["Attack"].Reset();
            GameObject proj = Instantiate(bullet, transform.position, Quaternion.identity);
            Projectile sb = proj.GetComponent<Projectile>();
            sb.Shoot(new Vector2((lastMovement.x), lastMovement.y), 300);
            audio.PlayOneShot(shootSFX);
        }

        if (hasBombs)
        {
            if (InputSystem.actions["Special"].IsPressed())
            {
                InputSystem.actions["Special"].Reset();
                GameObject proj = Instantiate(bomb, transform.position, Quaternion.identity);
                Projectile b = proj.GetComponent<Projectile>();
                b.Shoot(new Vector2(lastMovement.x, lastMovement.y), 300);
                bombs--;
                ui.setBombs(bombs);
                if (bombs == 0)
                {
                    hasBombs = false;
                }
            }
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
            TakeDamage(5);
        }
        else if (other.gameObject.tag == "PinkZombie")
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth--;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            Destroy(this.gameObject);
            gm.SendMessage("GameOverScreen", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Heal(int restoredHealth)
    {
        currentHealth += restoredHealth;
        healthBar.SetHealth(currentHealth);
    }

    public void SpeedBoost()
    {
        float newSpeed;
        float duration = 10f;
        float count = 0f;
        while (count < duration)
        {
            newSpeed = speed * 5;
            Debug.Log("Speed Boost Active");
            rb.linearVelocity = movement * newSpeed;
            count += Time.deltaTime;
        }

        speed = 5f;
    }
}
