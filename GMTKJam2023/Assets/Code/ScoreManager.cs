using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    int score = 0;

    //public Text scoreText;

    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //scoreText.text = score.ToString();
        Debug.Log("current score: " + score);
    }

    public void addPoint()
    {
        score += 1;
        Debug.Log("current score: " + score);
    }

}
