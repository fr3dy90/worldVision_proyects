using UnityEngine;

public class QueHariasController : BaseController
{
    [SerializeField] private int index = 0;
    [SerializeField, TextArea(3,3)] private string _reflexionQueHarias;
    public override void Initialize()
    {
        base.Initialize();
        index = 0;
        if (_view is QueHariasView view)
        {
            view._buttonI.onClick.AddListener(CheckSituacion);
            view._buttonII.onClick.AddListener(CheckSituacion);
            view.Settext(index);
        }
    }

    public void CheckSituacion()
    {
       index++;
       if (_view is QueHariasView view)
       {
           if (index < view.GetQueHarias().Length)
           {
               view.Settext(index);
           }
           else
           {
               RefexionView.Instance.SetReflexionText(_reflexionQueHarias, _view.GetCanvasGroup());
           }
       }
    }
}

//boton inicio por boton de play
//botyon salir por boton de puerta de salida