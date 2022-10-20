using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UniRx;
using UnityEngine;

public class GameManagerController
{    
    private IState _loadLevelDataState, _loadLevelState, _loadLevelSelectionState, _unloadLevelState;
    private GameObject _self;
    private EntityData _playerEntityData;
    public GameManagerController(SaveHandler saveHandler, SceneLoader sceneLoader, LevelDataDB levelDataDB, GameObject self, EntityData playerEntityData)
    {
        _loadLevelState = new LoadLevelState(sceneLoader, saveHandler);
        _loadLevelSelectionState = new LoadLevelSelectionState(sceneLoader);
        _loadLevelDataState = new LoadLevelDataState(saveHandler);
        _self = self;
        _playerEntityData = playerEntityData;
        LevelManager.SetLevelDataDB(levelDataDB);
    }

    public void StartGame()
    {        
        _loadLevelDataState?.EnterState();
        if (_playerEntityData != null)
        {
            _playerEntityData.CurrentHealthCountRx.Where((health) => health <= 0).Subscribe((_) =>
            {
                var currentLevelData = LevelManager.CurrentLevelData;
                if (currentLevelData != null)
                {
                    currentLevelData.CurrentLevelStatus = LevelData.LevelStatus.Failed;                    
                }
            });
        }
        LevelManager.CurrentLevelDataRx.Subscribe(OnLevelDataChanged).AddTo(_self);
    }

    private void OnLevelDataChanged(LevelData levelData)
    {
        if (levelData == null)
        {
            _loadLevelSelectionState?.EnterState();
        }
        else
        {
            _loadLevelState?.EnterState();
        }
    }
    
}
