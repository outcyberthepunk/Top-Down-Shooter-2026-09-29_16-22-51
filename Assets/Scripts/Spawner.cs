
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    private float spawnCooldown = 5f;
    private float countdown;
    

    void Update()
    {
        countdown += Time.deltaTime;
        if (countdown > spawnCooldown)
        {
            GameObject obj = objects[Random.Range(0, objects.Length)];
            Instantiate(obj);
            countdown = 0;
        }
    }
}
