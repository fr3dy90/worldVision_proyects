using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private Dictionary<MyEnums.GameState, IView> _views = new ();

    public void RegisterView(MyEnums.GameState viewName, IView view)
    {
        if (!_views.ContainsKey(viewName))
        {
            _views.Add(viewName, view);
        }
    }

    public void ShowView(MyEnums.GameState viewName)
    {
        if (_views.ContainsKey(viewName))
        {
            _views[viewName].Show();
        }
    }

    public void HideView(MyEnums.GameState viewName)
    {
        if (_views.ContainsKey(viewName))
        {
            _views[viewName].Hide();
        }
    }
}
