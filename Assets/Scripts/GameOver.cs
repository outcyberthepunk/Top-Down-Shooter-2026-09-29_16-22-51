using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
   public TMP_Text finalScoreText;
   public TMP_Text newRecordText;
   private AudioSource audio;
   public AudioSource music;
   public GameManager gm;
   [SerializeField] private AudioClip audioClip;
   public ScoreHandler scoreHandler;

   private void Awake()
   {
      audio = GetComponent<AudioSource>();
      music = GetComponent<AudioSource>();
   }

   public void Appear(int finalScore)
   {
      music.Pause();
      Time.timeScale = 0;
      gameObject.SetActive(true);
      finalScoreText.text = "Final Score: " + finalScore.ToString();
   }

   public void Restart()
   {
      SceneManager.LoadScene("game");
      Time.timeScale = 1;
   }
}
