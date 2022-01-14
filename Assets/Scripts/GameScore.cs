using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public GameObject Background;
    public GameObject bg2;
    public GameObject bg3;
    public Text scoreText;

    Text scoreTextUI;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

    void Start()
    {
        scoreTextUI = GetComponent<Text> ();
    }

    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:000000}", score);
        scoreTextUI.text = scoreStr;

        scoreText.text = ((int)score).ToString();

        if (scoreText.text.Equals("500"))
        {
            Background.SetActive(false);
            bg2.SetActive(true);
            bg3.SetActive(false);
        }

        if (scoreText.text.Equals("1000"))
        {
            Background.SetActive(false);
            bg2.SetActive(false);
            bg3.SetActive(true);
        }

    }
}
