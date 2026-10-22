using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text hiScoreText;

    
    public void SetScore(int score)
    {
        scoreText.SetText("Score " + score.ToString("000000"));
    }

    public void SetHiScore(int hiScore)
    {
        hiScoreText.SetText("HI " + hiScore.ToString("000000"));
    }
}
