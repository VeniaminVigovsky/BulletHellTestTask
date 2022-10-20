using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class EndScreenController
{
    
    private GameObject _endScreenPanel;
    private TMP_Text _endScreenText;
    private EndScreen _endScreen;

    public EndScreenController(GameObject endScreenPanel, TMP_Text endScreenText, EndScreen endScreen)
    {        
        _endScreenPanel = endScreenPanel;
        _endScreenText = endScreenText;
        _endScreen = endScreen;
        if (_endScreenPanel != null)
        {
            _endScreenPanel.SetActive(false);
        }

        var levelData = LevelManager.CurrentLevelData;
        if (levelData != null)
        {
            levelData.CurrentLevelStatusRx.Subscribe(OnCurrentLevelStatusChanged).AddTo(_endScreen);
        }

    }

    private void OnCurrentLevelStatusChanged(LevelData.LevelStatus levelStatus)
    {
        if (_endScreen == null)
        {
            LevelManager.SetLevelData(null);
        }

        if (levelStatus == LevelData.LevelStatus.Failed || levelStatus == LevelData.LevelStatus.Finished)
        {
            if (_endScreenText != null)
            {
                _endScreenText.text = levelStatus == LevelData.LevelStatus.Finished ? "VICTORY" : "FAILED";
            }

            _endScreen.StopAllCoroutines();
            _endScreen.StartCoroutine(EndSequence());
        }
    }

    private IEnumerator EndSequence()
    {
        Time.timeScale = 0.0f;
        if (_endScreenPanel == null)
        {
            yield return null;
        }
        else
        {
            _endScreenPanel.SetActive(true);
            yield return new WaitForSecondsRealtime(2.0f);
        }

        Time.timeScale = 1.0f;

        LevelManager.SetLevelData(null);
    }
}
