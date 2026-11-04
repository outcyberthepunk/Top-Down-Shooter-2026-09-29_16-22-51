using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text hiScoreText;
    public Image[] bombs;

    
    public void SetScore(int score)
    {
        scoreText.SetText("Score " + score.ToString("000000"));
    }
    
    public void setBombs(int bombsRemaining)
    {
        switch (bombsRemaining)
        {
            case 5:
                bombs[0].enabled = true;
                bombs[1].enabled = true;
                bombs[2].enabled = true;
                bombs[3].enabled = true;
                bombs[4].enabled = true;
                break;
            case 4:
                bombs[0].enabled = false;
                bombs[1].enabled = true;
                bombs[2].enabled = true;
                bombs[3].enabled = true;
                bombs[4].enabled = true;
                break;
            case 3:
                bombs[0].enabled = false;
                bombs[1].enabled = false;
                bombs[2].enabled = true;
                bombs[3].enabled = true;
                bombs[4].enabled = true;
                break;
            case 2:
                bombs[0].enabled = false;
                bombs[1].enabled = false;
                bombs[2].enabled = false;
                bombs[3].enabled = true;
                bombs[4].enabled = true;
                break;
            case 1:
                bombs[0].enabled = false;
                bombs[1].enabled = false;
                bombs[2].enabled = false;
                bombs[3].enabled = false;
                bombs[4].enabled = true;
                break;
            case 0:
                bombs[0].enabled = false;
                bombs[1].enabled = false;
                bombs[2].enabled = false;
                bombs[3].enabled = false;
                bombs[4].enabled = false;
                break;
        }
    }
}
