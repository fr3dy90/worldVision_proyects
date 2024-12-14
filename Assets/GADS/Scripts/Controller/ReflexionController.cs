public class ReflexionController : BaseController
{
    public string reflexionText;
    public override void OnSetView()
    {
        base.OnSetView();
        if (_view is RefexionView view)
        {
            _view.OnSetView();
            //view.SetReflexionText(reflexionText);
        }
    }
}