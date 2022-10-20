using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderController
{
    private SceneLoader _sceneLoaderView;

    private Dictionary<int, bool> _loadedScenes;

    private Queue<IEnumerator> _coroutineQueue;

    private IEnumerator _currentCoroutine;

    public SceneLoaderController(SceneLoader sceneLoaderView)
    {
        _sceneLoaderView = sceneLoaderView;
        _loadedScenes = new Dictionary<int, bool>();
        _loadedScenes.Add(SceneData.StartSceneBuildIndex, true);
        _loadedScenes.Add(SceneData.LevelSceneBuildIndex, false);
        _loadedScenes.Add(SceneData.LevelSelectionSceneBuildIndex, false);
        _loadedScenes.Add(SceneData.UiSceneBuildIndex, false);

        _coroutineQueue = new Queue<IEnumerator>();
    }

    public void LoadLevelScene()
    {
        LoadScene(SceneData.LevelSceneBuildIndex);
    }
    public void UnloadLevelScene()
    {
        UnloadScene(SceneData.LevelSceneBuildIndex);
    }
    public void LoadLevelSelectionScene()
    {
        LoadScene(SceneData.LevelSelectionSceneBuildIndex);
    }
    public void UnloadLevelSelectionScene()
    {
        UnloadScene(SceneData.LevelSelectionSceneBuildIndex);
    }
    public void LoadUIScene()
    {
        LoadScene(SceneData.UiSceneBuildIndex);
    }
    public void UnloadUIScene()
    {
        UnloadScene(SceneData.UiSceneBuildIndex);
    }

    private void LoadScene(int buildIndex)
    {
        if (_sceneLoaderView == null || _coroutineQueue == null) return;

        if (buildIndex >= SceneManager.sceneCountInBuildSettings) return;


        if (_currentCoroutine == null)
        {
            _currentCoroutine = LoadSceneAsync(buildIndex);
            _sceneLoaderView.ExecuteSceneOperation(_currentCoroutine);            
        }
        else
        {
            _coroutineQueue.Enqueue(LoadSceneAsync(buildIndex));
        }
    }

    private void Next()
    {
        if (_coroutineQueue == null) return;

        if (_coroutineQueue.Count <= 0)
        {
            _currentCoroutine = null;
            return;
        }

        _currentCoroutine = _coroutineQueue.Dequeue();
        _sceneLoaderView.ExecuteSceneOperation(_currentCoroutine);
    }

    private void UnloadScene(int buildIndex)
    {
        if (_sceneLoaderView == null || _coroutineQueue == null) return;

        if (buildIndex >= SceneManager.sceneCountInBuildSettings) return;

        if (_loadedScenes.ContainsKey(buildIndex))
        {            

            if (_loadedScenes[buildIndex])
            {
                if (_currentCoroutine == null)
                {
                    _currentCoroutine = UnloadSceneAsync(buildIndex);
                    _sceneLoaderView.ExecuteSceneOperation(_currentCoroutine);
                }
                else
                {
                    _coroutineQueue.Enqueue(UnloadSceneAsync(buildIndex));
                }
            }
        }
    }

    private IEnumerator LoadSceneAsync(int buildIndex)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        _loadedScenes[buildIndex] = true;

        Next();
    }

    private IEnumerator UnloadSceneAsync(int buildIndex)
    {
        var asyncOperation = SceneManager.UnloadSceneAsync(buildIndex);        

        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        _loadedScenes[buildIndex] = false;

        Next();
    }
}
