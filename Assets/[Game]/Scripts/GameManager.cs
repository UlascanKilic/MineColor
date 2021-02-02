using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool isGameEnd = false;
   
    public Text scoreText;
   
    public void EndGame()
    {
        if (isGameEnd == false)
        {
            isGameEnd = true;
                    
            Invoke("Restart", 0);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
