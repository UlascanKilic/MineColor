using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScorePass : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highScoreText;

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "High Score: " + Mathf.Round(ScoreManager.highScoreCount);
    }
}
