using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] protected Text scoreText;
    private void Reset()
    {
        scoreText = GetComponent<Text>();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score; 
    }
}
