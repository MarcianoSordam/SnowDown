using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int scoreUpRate = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;

    public void ScoreUp()
    {
        score += scoreUpRate;
        //score up
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        //
    }
}
