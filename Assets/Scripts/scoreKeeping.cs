using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreKeeping : MonoBehaviour
{
    public int highScore;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        score = 3;
        highScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score > highScore)
            highScore = score;
        highscoreText.text = "High Score: " + highScore;
        if(score<=0)
        {
            scoreText.text="GameOver";
        }
        else
            scoreText.text = "Score: " + score;


    }
}
