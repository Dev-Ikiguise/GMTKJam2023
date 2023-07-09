using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;

    public int score;

    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        Debug.Log("current score: " + score);
    }

    public void Update()
    {
        scoreText.text = "FARMER IN: " + score.ToString();
    }


    public void addPoint()
    {
        score += 1;
        Debug.Log("current score: " + score);
    }

}
