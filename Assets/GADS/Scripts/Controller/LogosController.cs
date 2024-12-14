using UnityEngine;

public class LogosController : BaseController
{
    [SerializeField] private float fadeDuration;
    [SerializeField] private float timeInscreen;
    //[SerializeField] private LogosView view;

    public override void OnSetView()
    {
        base.OnSetView();
        _view.OnSetView();
    }

    public override void OnStart()
    {
        if (_view is LogosView view)
        {
            view.FadeLogos(fadeDuration, timeInscreen,
                () => { GameManager.Instance.ChangeState(MyEnums.GameState.Intro); });
        }
    }
}