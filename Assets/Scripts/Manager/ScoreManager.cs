using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int scorePoint;

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
    }

    public void ResetScorePoint()
    {
        scorePoint = 0;
    }
}
