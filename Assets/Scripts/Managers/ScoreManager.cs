using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int scorePoint;
    private const int maxScorePoint = 999999999;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }

    public int GetScorePoint()
    {
        return scorePoint;
    }

    public void AddScorePoint(int scorePoint)
    {
        this.scorePoint += scorePoint;

        if (this.scorePoint > maxScorePoint)
        {
            LevelManager.Instance.LoadGameWinScene();
        }
    }

    public void ResetScorePoint()
    {
        scorePoint = 0;
    }
}
