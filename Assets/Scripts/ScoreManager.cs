using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text redTeamScoreText;
    public int redTeamScore;

    public TMP_Text greenTeamScoreText;
    public int greenTeamScore;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int teamId, int amount)
    {
        if(teamId == 0)
        {
            greenTeamScore += amount;
        }
        else
        {
            redTeamScore += amount;
        }

        redTeamScoreText.SetText(redTeamScore.ToString());
        greenTeamScoreText.SetText(greenTeamScore.ToString());
    }
}
