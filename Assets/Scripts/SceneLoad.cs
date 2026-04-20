using Cysharp.Threading.Tasks;
using System.Threading;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad
{
     private FadeManager _fadeManager;

    public SceneLoad(FadeManager fadeManager)
    {
        _fadeManager = fadeManager;
    }

    public void LoadNextScene(int sceneIndex,System.Action sceneChangeEndCallback,CancellationToken cancellationToken)
    {
        _fadeManager.FadeOut(() =>
        {
            LoadingScene(sceneIndex, sceneChangeEndCallback, cancellationToken).Forget();
        },cancellationToken);
    }

    private async UniTask LoadingScene(int sceneIndx,System.Action scneChangeEndCallback,CancellationToken cancellationToken)
    {
        await SceneManager.LoadSceneAsync(sceneIndx);
        _fadeManager.FadeIN(scneChangeEndCallback,cancellationToken);
    }
}
