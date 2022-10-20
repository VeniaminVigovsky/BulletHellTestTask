using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName ="New LevelDataDB", menuName = "GameData/LevelData/LevelDataDB")]
public class LevelDataDB : ScriptableObject
{
    public List<LevelData> LevelDataList => _levelDataList;

    [SerializeField] private List<LevelData> _levelDataList;

    public LevelData GetLevelData(int levelID)
    {
        if (_levelDataList == null || _levelDataList.Count <= levelID) return null;

        var levelsOfId = _levelDataList.Where((levelData) => levelData.LevelID == levelID);
        if (levelsOfId == null || levelsOfId.Count() <= 0) return null;
        return levelsOfId.First();
    }

    public int GetOpenLevelID()
    {
        if (_levelDataList == null) return -1;
        var openLevels = _levelDataList.Where((levelData) => levelData.CurrentLevelStatus == LevelData.LevelStatus.Opened);
        if (openLevels == null || openLevels.Count() <= 0) return -1;
        return openLevels.First().LevelID;
    }

    public bool HasOpenedLevels()
    {
        if (_levelDataList == null) return false;

        return _levelDataList.Any((levelData) => levelData.CurrentLevelStatus == LevelData.LevelStatus.Opened);        
    }

    public void SetLevelDataList(List<LevelData> levelDataList)
    {
        _levelDataList = levelDataList;
    }

    public void SetLevelData(LevelData levelData)
    {
        if (levelData == null || _levelDataList == null) return;

        var id = levelData.LevelID;
        var levelDataFromList = GetLevelData(id);
        if (levelDataFromList == null)
        {
            _levelDataList.Add(levelData);
        }
        else
        {
            var levelListIndex = _levelDataList.IndexOf(levelDataFromList);
            if (levelListIndex < 0)
            {
                _levelDataList.Add(levelData);
            }
            else
            {
                _levelDataList[levelListIndex] = levelData;
            }
        }       

    }

    
}
