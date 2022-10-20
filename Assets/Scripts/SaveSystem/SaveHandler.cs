using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    [SerializeField] private LevelDataDB _levelDataDB;
    [SerializeField] private EntityData _asteroidEntityData;
    [SerializeField] private EntityData _playerEntityData;
    [SerializeField] private SpawnerData _spawnerData;

    private SaveHandlerController _saveHandlerController;
    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    private void Init()
    {
        if (_isInit) return;

        _saveHandlerController = new SaveHandlerController(_levelDataDB, _asteroidEntityData, _playerEntityData, _spawnerData);

        _isInit = true;
    }

    public void LoadGameData()
    {
        if (!_isInit) Init();

        _saveHandlerController?.LoadGameData();
    }
    
    public void SaveGameData()
    {
        if (!_isInit) Init();

        _saveHandlerController?.SaveGameData();
    }

    public bool HasOpenedLevel()
    {
        if (!_isInit) Init();
        if (_saveHandlerController == null)
            return false;
        return _saveHandlerController.HasOpenedLevel();
    }
    public int GetOpenLevelID()
    {
        if (!_isInit) Init();
        if (_saveHandlerController == null)
            return -1;
        else return _saveHandlerController.GetOpenLevelID();
    }

    public void LoadLevelData(int levelID)
    {
        if (!_isInit) Init();

        _saveHandlerController?.LoadLevelData(levelID);
    }
}
