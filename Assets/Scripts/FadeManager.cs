using LitMotion;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class FadeManager
{
    //フェード対象のアルファ操作用
    private CanvasGroup _canvasGroup;
    //フェード時間
    private float _fadeTime = 0.5f;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="canvasGroup"></param>


    public FadeManager(CanvasGroup canvasGroup)
    {
        _canvasGroup = canvasGroup;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fadeEndCallback"></param>フェードが終了したら呼び出される
    /// <param name="cancellationToken"></param>途中破棄された場合
    public  void FadeIN(System.Action fadeEndCallback, CancellationToken cancellationToken)
    {
        LMotion.Create(_canvasGroup.alpha,0f,_fadeTime)
            .WithEase(Ease.Linear)
            .WithOnComplete(() =>
            {
                //処理が終わったらコールバックを呼び出す
                fadeEndCallback?.Invoke();
                //透明になったらオブジェクトを非表示にする
                _canvasGroup.gameObject.SetActive(false);
            })
            .Bind(x => _canvasGroup.alpha = x)
            .ToUniTask(cancellationToken);
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fadeEndCallback"></param>フェードが終了したら呼び出される
    /// <param name="cancellationToken"></param>途中破棄された場合
    public void FadeOut(System.Action fadeEndCallback, CancellationToken cancellationToken)
    {
        _canvasGroup.gameObject.SetActive(true);
        LMotion.Create(_canvasGroup.alpha, 1f, _fadeTime)
            .WithEase(Ease.Linear)
            .WithOnComplete(() =>
            {
                //処理が終わったらコールバックを呼び出す
                fadeEndCallback?.Invoke();
                //透明になったらオブジェクトを非表示にする
                _canvasGroup.gameObject.SetActive(false);
            })
            .Bind(x => _canvasGroup.alpha = x)
            .ToUniTask(cancellationToken);

    }
}
