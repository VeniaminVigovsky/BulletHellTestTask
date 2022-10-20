using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandlerController
{
    private SaveData _saveData;
    private LevelDataDB _levelDataDB;
    private EntityData _asteroidEntityData;
    private EntityData _playerEntityData;
    private SpawnerData _spawnerData;

    public SaveHandlerController(LevelDataDB levelDataDB, EntityData asteroidEntityData, EntityData playerEntityData, SpawnerData spawnerData)
    {
        _levelDataDB = levelDataDB;
        _asteroidEntityData = asteroidEntityData;
        _playerEntityData = playerEntityData;
        _spawnerData = spawnerData;        
    }

    public void SaveGameData()
    {
        if (_levelDataDB == null || _playerEntityData == null) return;

        var currentLevelData = LevelManager.CurrentLevelData;

        if (currentLevelData != null)
        {
            currentLevelData.PlayerCurrentHealth = _playerEntityData.CurrentHealthCount;
        }

        var levelDataList = _levelDataDB.LevelDataList;
        if (levelDataList == null) return;
        _saveData = new SaveData(levelDataList);
        SaveDataWriteHandler.WriteSaveData(_saveData);
    }

    public void LoadGameData()
    {
        _saveData = SaveDataWriteHandler.ReadSaveData();

        if (_saveData == null || _levelDataDB == null) return;

        var levelDataList = _saveData.LevelDataList;
        if (levelDataList == null || levelDataList.Count <= 0) return;

        foreach (var levelData in levelDataList)
        {
            _levelDataDB.SetLevelData(levelData);
        }
    }

    public bool HasOpenedLevel()
    {
        if (_levelDataDB == null)
            return false;
        else return _levelDataDB.HasOpenedLevels();
    }
    public int GetOpenLevelID()
    {
        if (_levelDataDB == null)
            return -1;
        else return _levelDataDB.GetOpenLevelID();
    }

    public void LoadLevelData(int levelID)
    {
        if (_levelDataDB == null 
            || _asteroidEntityData == null 
            || _spawnerData == null 
            || _playerEntityData == null) return;

        var levelData = _levelDataDB.GetLevelData(levelID);
        if (levelData == null) return;

        _asteroidEntityData.MovementSpeed = levelData.AsteroidSpeed;
        _spawnerData.TimeBetweenSpawns = levelData.TimeBetweenSpawns;
        _playerEntityData.CurrentHealthCount = levelData.PlayerCurrentHealth;
    }
}
