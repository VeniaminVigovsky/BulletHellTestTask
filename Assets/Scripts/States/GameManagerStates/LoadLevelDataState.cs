using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelDataState : IState
{
    private SaveHandler _saveHandler;    

    public LoadLevelDataState(SaveHandler saveHandler)
    {
        _saveHandler = saveHandler;
    }

    public void EnterState()
    {
        if (_saveHandler == null) return;

        _saveHandler.LoadGameData();    
        
        LevelManager.SetLevelData(null);
    }
}
