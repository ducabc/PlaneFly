using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    protected int score = 0;
    [SerializeField] protected ScoreUI scoreUI;
    private static GameCtrl instance;
    public static GameCtrl Instance=> instance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Reset()
    {
        scoreUI = GameObject.FindObjectOfType<ScoreUI>();
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreUI.UpdateScore(this.score);
    }
}
