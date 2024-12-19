using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] private MyEnums.GameState _state;
    [SerializeField] protected BaseView _view;
    
    public virtual void Initialize()
    {
        if (_view == null)
        {
            _view = GetComponentInChildren<BaseView>();
        }
        _view.Initialize();
    }

    public virtual void OnSetView()
    {
        _view.OnSetView();
    }

    public virtual void OnStart()
    {
        _view.Show();
    }
    
    public MyEnums.GameState GetState()
    {
        return _state;
    }

    public IView GetView()
    {
        return _view;
    }
}