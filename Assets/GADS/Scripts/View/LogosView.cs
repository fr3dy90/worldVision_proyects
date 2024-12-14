using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LogosView : BaseView
{
    [SerializeField] private Image[] _logos;
    [SerializeField] private CanvasGroup _logosCg;

    public override void OnSetView()
    {
        base.OnSetView();
        for (int i = 0; i < _logos.Length; i++)
        {
            _logos[i].gameObject.SetActive(false);
        }

        _logosCg.alpha = 0;
    }

    public async void FadeLogos(float duration, float timeInScreen, Action onCompleted)
    {
        for (int i = 0; i < _logos.Length; i++)
        {
            _logos[i].gameObject.SetActive(true);
            await FadeManager.FadeInCanvas(_logosCg, duration);
            await UniTask.WaitForSeconds(timeInScreen);
            await FadeManager.FadeOut(_logosCg, duration);
            _logos[i].gameObject.SetActive(false);
        }

        await UniTask.WaitForSeconds(1);
        onCompleted?.Invoke();
    }
}
