using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Player player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);

        }
    }
}
