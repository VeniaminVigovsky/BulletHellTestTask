using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public static class LevelManager
{
    public static ReactiveProperty<LevelData> CurrentLevelDataRx
    {
        get
        {
            if (_currentLevelDataRx == null) 
            {
                _currentLevelDataRx = new ReactiveProperty<LevelData>();
            }
            return _currentLevelDataRx;
        }
    }
    public static LevelData CurrentLevelData { get; private set; }
    private static LevelDataDB _levelDataDB;

    private static ReactiveProperty<LevelData> _currentLevelDataRx;

    public static void SetLevelDataDB(LevelDataDB levelDataDB)
    {
        _levelDataDB = levelDataDB;
    }

    public static void SetLevelData(LevelData levelData)
    {
        CurrentLevelData = levelData;        

        CurrentLevelDataRx.Value = levelData;

        if (levelData != null)
        {
            if (levelData.CurrentLevelStatus == LevelData.LevelStatus.Started || levelData.CurrentLevelStatus == LevelData.LevelStatus.Failed)
            {
                if (levelData.CurrentLevelStatus == LevelData.LevelStatus.Started)
                {
                    levelData.TargetKillCount = Random.Range(10, 21);
                    levelData.AsteroidSpeed = Random.Range(200.0f, 450.0f);
                    levelData.TimeBetweenSpawns = Random.Range(0.4f, 1.0f);
                }

                levelData.CurrentKillCount = 0;
                levelData.PlayerCurrentHealth = 3;

                levelData.CurrentLevelStatus = LevelData.LevelStatus.Unfinished;
            }

            levelData.CurrentKillCountRx.Where((killCount) => killCount >= levelData.TargetKillCount).Subscribe((_) => 
            {
                levelData.CurrentLevelStatus = LevelData.LevelStatus.Finished;

                if (_levelDataDB != null)
                {
                    var nextLevelData = _levelDataDB.GetLevelData(levelData.LevelID + 1);
                    if (nextLevelData != null && nextLevelData.CurrentLevelStatus == LevelData.LevelStatus.Closed)
                    {
                        nextLevelData.CurrentLevelStatus = LevelData.LevelStatus.Opened;
                    }
                }
                
            });
        }
    }
}
