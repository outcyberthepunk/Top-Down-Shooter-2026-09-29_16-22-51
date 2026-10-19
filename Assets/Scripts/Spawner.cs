
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    private float spawnCooldown = 3.5f;
    private float countdown;
    private Time gameTime;
    public ScoreHandler scoreHandler;
    

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
