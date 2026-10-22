using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameOver gameOver;
   public ScoreHandler scoreHandler;
   [SerializeField] private UIManager ui;
   
   
   public void GameOverScreen()
   {
      gameOver.Appear(scoreHandler.score);
      
      // Set high score
      if (PlayerPrefs.HasKey("HiScore"))
      {
         if (scoreHandler.score > PlayerPrefs.GetInt("HiScore"))
         {
            PlayerPrefs.SetInt("HiScore", scoreHandler.score);
         }
         else
         {
            PlayerPrefs.SetInt("HiScore", 1000);
         }
      }
   }
   
   
}
