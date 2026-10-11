using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private UIManager ui;
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    
    private Vector2 lastMovement = new Vector2(0, -1);
    private Animator animator;
    private int health = 10;
    private int maxHealth;
    private bool canFireSpecial = false;
    private int score;
    private int hiScore = 1000;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        score = 0;

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
