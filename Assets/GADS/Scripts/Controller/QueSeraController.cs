using UnityEngine;
using UnityEngine.UI;

public class QueSeraController : BaseController
{
    [SerializeField] private MyEnums.QueSeraStruct[] definitions;
    [SerializeField] private int index = 0;

    [SerializeField, TextArea(3, 3)] private string queSeraReflexion;

    public override void Initialize()
    {
        base.Initialize();
        if (_view is QueSeraView view)
        {
            view.SetContentText(definitions[index].definicion);
            for (int i = 0; i < view.Helpers().Length; i++)
            {
                int i1 = i;
                view.Helpers()[i1].GetComponent<Button>().onClick.AddListener(() =>
                {
                    CompareButton(view.Helpers()[i1]);
                });
            }
        }
    }

    public void CompareButton(ButtonHelpher helpher)
    {
        if (helpher._buttonEmocion == definitions[index].id)
        {
            index++;
            if (index >= definitions.Length)
            {
                RefexionView.Instance.SetReflexionText(queSeraReflexion, _view.GetCanvasGroup());
                return;
            }
            if (_view is QueSeraView view)
            {
                view.SetContentText(definitions[index].definicion);
            }
        }
    }
}