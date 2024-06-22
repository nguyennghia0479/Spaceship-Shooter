using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int scorePoint;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public int GetScorePoint()
    {
        return scorePoint;
    }

    public void AddScorePoint(int scorePoint)
    {
        this.scorePoint += scorePoint;
    }

    public void ResetScorePoint()
    {
        scorePoint = 0;
    }
}
