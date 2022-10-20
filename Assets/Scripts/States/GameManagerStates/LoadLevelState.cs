using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class LoadLevelState : IState
{
    private SceneLoader _sceneLoader;
    private SaveHandler _saveHandler;

    public LoadLevelState(SceneLoader sceneLoader, SaveHandler saveHandler)
    {
        _sceneLoader = sceneLoader;
        _saveHandler = saveHandler;
    }

    public void EnterState()
    {
        if (_sceneLoader == null || _saveHandler == null || LevelManager.CurrentLevelData == null) return;

        var levelID = LevelManager.CurrentLevelData.LevelID;

        _saveHandler.LoadLevelData(levelID);

        _sceneLoader.UnloadLevelSelection();

        _sceneLoader.LoadLevelScene();
        _sceneLoader.LoadUIScene();
    }
}
