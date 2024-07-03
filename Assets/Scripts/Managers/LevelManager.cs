using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Level
{
    MainMenuScene, GameScene, GameOverScene, GameWinScene
}

public class LevelManager : Singleton<LevelManager>
{
    private Level level;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }

    public void LoadMainMenuScene()
    {
        level = Level.MainMenuScene;
        LoadScene(Level.MainMenuScene.ToString());
    }

    public void LoadGameScene()
    {
        ScoreManager.Instance.ResetScorePoint();
        BackgroundManager.Instance.UpdateBackground();

        level = Level.GameScene;
        LoadScene(Level.GameScene.ToString());
    }

    public void LoadGameOverScene()
    {
        level = Level.GameOverScene;
        LoadScene(Level.GameOverScene.ToString(), 1.5f);
    }

    public void LoadGameWinScene()
    {
        level = Level.GameWinScene;
        LoadScene(Level.GameWinScene.ToString(), 1.5f);
    }

    public bool IsMainMenuScene()
    {
        return level == Level.MainMenuScene;
    }

    public bool IsGameScene()
    {
        return level == Level.GameScene;
    }

    public bool IsGameOverScene()
    {
        return level == Level.GameOverScene;
    }

    private void LoadScene(string sceneName, float time = 0)
    {
        StartCoroutine(LoadSceneAsyncRoutine(sceneName, time));
    }

    private IEnumerator LoadSceneAsyncRoutine(string sceneName, float time)
    {
        yield return new WaitForSeconds(time);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / .9f);

            yield return null;
        }
    }
}
