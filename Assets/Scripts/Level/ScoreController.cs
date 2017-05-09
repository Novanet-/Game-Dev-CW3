using System;
using com.kleberswf.lib.core;
using Entity;
using UnityEngine;

public class ScoreController : Singleton<ScoreController>
{
    #region Public Properties

    public int CurrentScore { get; private set; }
    public int EnemiesKilled { get; private set; }
    public int TimeSurvived { get; private set; }

    #endregion Public Properties

    #region Public Methods

    internal void UpdateTimeSurvived(float currentGameTimeElapsed)
    {
        TimeSurvived = Convert.ToInt32(Mathf.Floor(currentGameTimeElapsed));
    }

    #endregion Public Methods

    #region Internal Methods

    internal void AddKilledEnemy(EnemyController enemy)
    {
        CurrentScore += enemy.ScoreValue;
        ++EnemiesKilled;
    }

    #endregion Internal Methods

    #region Private Methods

    // Use this for initialization
    private void Start()
    {
        CurrentScore = 0;
        EnemiesKilled = 0;
        TimeSurvived = 0;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    #endregion Private Methods
}