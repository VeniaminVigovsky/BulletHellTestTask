using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private ReactiveProperty<bool> _sceneLoaderIsBusyRx;

    private SceneLoaderController _sceneLoaderController;
    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        _sceneLoaderController = new SceneLoaderController(this);
        _isInit = true;
    }

    public void LoadLevelSelectionScene()
    {
        if (!_isInit) Init();

        _sceneLoaderController?.LoadLevelSelectionScene();
    }

    public void UnloadLevelSelection()
    {
        if (!_isInit) Init();

        _sceneLoaderController?.UnloadLevelSelectionScene();
    }
    public void LoadLevelScene()
    {
        if (!_isInit) Init();

        _sceneLoaderController?.LoadLevelScene();
    }
    public void UnloadLevelScene()
    {
        if (!_isInit) Init();

        _sceneLoaderController?.UnloadLevelScene();
    }

    public void LoadUIScene()
    {
        if (!_isInit) Init();

        _sceneLoaderController?.LoadUIScene();
    }
    public void UnloadUIScene()
    {
        if (!_isInit) Init();

        _sceneLoaderController?.UnloadUIScene();

    }

    public void ExecuteSceneOperation(IEnumerator sceneOperationCoroutine)
    {
        StartCoroutine(sceneOperationCoroutine);
    }
}
