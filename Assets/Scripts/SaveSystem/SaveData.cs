using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public List<LevelData> LevelDataList => _levelDataList;

    [SerializeField] private List<LevelData> _levelDataList;

    public SaveData(List<LevelData> levelDataList)
    {
        _levelDataList = levelDataList;
    }
}
