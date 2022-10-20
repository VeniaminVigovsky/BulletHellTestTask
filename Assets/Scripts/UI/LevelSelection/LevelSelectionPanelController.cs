using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionPanelController
{	
	public LevelSelectionPanelController(LevelDisplay levelDisplayPrefab, Transform selfT, LevelDataDB levelDataDb)
	{
		if (levelDisplayPrefab == null || selfT == null || levelDataDb == null) return;

		var levelDataList = levelDataDb.LevelDataList;
		if (levelDataList != null)
		{
			foreach (var levelData in levelDataList)
			{
				var levelDisplay = Object.Instantiate(levelDisplayPrefab, selfT);
				levelDisplay.SetUpDisplay(levelData);
			}
		}
	}
}
