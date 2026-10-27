
using System.Threading;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    private float spawnCooldown = 2f;
    private float countdown;
    private float gameTime;
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

        gameTime += Time.deltaTime;
        if (gameTime > 60)
        {
            SpeedUp(1.5f);
        }

        if (gameTime > 120)
        {
            SpeedUp(0.7f);
        }
    }

    public void SpeedUp(float newSpawnCooldown)
    {
        spawnCooldown = newSpawnCooldown;
    }
}
