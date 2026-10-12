using System;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    [SerializeField] private float speed;
    [SerializeField] private int strength;
    [SerializeField] public GameObject player;
    private Animator anim;
    [SerializeField] private int damage;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDir = direction;
            
        }
    }

    void FixedUpdate()
    {
        if (target)
        {
            rb.linearVelocity = new Vector2(moveDir.x, moveDir.y) * speed;
            anim.SetFloat("MoveX", moveDir.x);
            anim.SetFloat("MoveY", moveDir.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "PlayerProjectile")
         {
             rb.linearVelocity = Vector2.zero;
             Hit();
         }
    }

    private void Hit()
    {
        strength--;
        if (strength == 0)
        {
            Destroy(this.gameObject);
            player.SendMessage("ScoreUpdate", SendMessageOptions.DontRequireReceiver);
        }
    }
    
}
