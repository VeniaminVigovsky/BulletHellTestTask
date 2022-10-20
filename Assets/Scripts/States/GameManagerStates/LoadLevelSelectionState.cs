using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class LoadLevelSelectionState : IState
{
    private SceneLoader _sceneLoader;

    public LoadLevelSelectionState(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;        
    }

    public void EnterState()
    {
        if (_sceneLoader == null) return;

        _sceneLoader.UnloadUIScene();
        _sceneLoader.UnloadLevelScene();
        EntityRegistry.ClearRegistry();
        _sceneLoader.LoadLevelSelectionScene();
    }

}
