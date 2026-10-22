using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public int score;
    public int hiScore = 1000;
    public bool hiScoreBeaten = false;
    public UIManager ui;
    [SerializeField] private Enemy enemy;
    //private string lastEnemyKilled;
    [SerializeField] private GameObject greenZombiePrefab;
    [SerializeField] private GameObject pinkZombiePrefab;

    void Start()
    {
      //  greenZombiePrefab = GameObject.FindGameObjectWithTag("GreenZombie");
      //  pinkZombiePrefab = GameObject.FindGameObjectWithTag("PinkZombie");
     //   lastEnemyKilled = enemy.tagOfEnemyKilled;
    }
    
    public void ScoreUpdate(string lastEnemyKilled)
    {
        if (lastEnemyKilled.Equals(greenZombiePrefab.tag))
        {
            score += 100;
            ui.SetScore(score);
            Debug.Log(score);
        }

        if (lastEnemyKilled.Equals(pinkZombiePrefab.tag))
        {
            score += 200;
            ui.SetScore(score);
            Debug.Log(score);
        }
        if (score > hiScore)
        {
            hiScoreBeaten = true;
            ui.SetHiScore(score);
        }
       
    }
}
