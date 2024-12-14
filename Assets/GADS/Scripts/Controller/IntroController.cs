public class IntroController : BaseController
{
    public override void Initialize()
    {
        base.Initialize();
        if (_view is IntroView view)
        {
            view.SetButton(OnButtonClic);
        }
    }

    private void OnButtonClic()
    {
         GameManager.Instance.ChangeState(MyEnums.GameState.Menu);
    }
}
