using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public static float highScoreCount;
    public float pointsPerSecond;

    public bool scoreIncreasing;
    
    public void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;

            scoreText.text = "Score: " + Mathf.Round(scoreCount);
            highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
        }
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
        }
        
    }
}
