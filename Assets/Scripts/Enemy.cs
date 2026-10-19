using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    [SerializeField] private float speed;
    [SerializeField] private int strength;
    public ScoreHandler scoreHandler;
    private Animator anim;
    [SerializeField] private int damage;
    public String tagOfEnemyKilled;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
        scoreHandler = FindObjectsByType<ScoreHandler>()[0];
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
            tagOfEnemyKilled = this.gameObject.tag;
            Debug.Log(tagOfEnemyKilled);
            scoreHandler.ScoreUpdate(tagOfEnemyKilled);
            Debug.Log("ScoreUpdate has been called");
            
        }
    }
    
}
