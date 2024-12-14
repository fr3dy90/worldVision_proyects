using UnityEngine;
using UnityEngine.UI;

public class MenuView : BaseView
{
    [SerializeField] private Button[] _buttons;

    public override void Initialize()
    {
        base.Initialize();
        int i1 = 0;
        for (int i = 0; i < _buttons.Length; i++)
        {
            i1 = i;
            _buttons[i1].onClick.AddListener(_buttons[i1].GetComponent<ButtonHelpher>().SetState);
        }
    }
}
