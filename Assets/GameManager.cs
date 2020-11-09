using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int scoreUpRate = 10;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject GameOVerText;
    int score = 0;

    void Start()
    {
        scoreText.text = score.ToString();

    }

    public void ScoreUp()
    {
        score += scoreUpRate;
        //score up
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        GameOVerText.SetActive(true);
    }
}
