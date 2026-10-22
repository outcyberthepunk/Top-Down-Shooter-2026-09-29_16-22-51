using System;
using UnityEngine;

    public class Projectile : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float timeToLive = 5f;
        private float countdown;
        private bool hasFired = false;
        public AudioSource bombExplosion;
        private AudioClip bombExplosionClip;
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (hasFired)
            {
                countdown += Time.deltaTime;
                if (countdown > timeToLive)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        public void Shoot(Vector2 direction, float force)
        {
                hasFired = true;
                rb.AddForce(direction * force);


        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(this.gameObject);
            if (this.gameObject.tag.Equals("Bomb"))
            {
                bombExplosion.PlayOneShot(bombExplosionClip);
            }
        }
    }
