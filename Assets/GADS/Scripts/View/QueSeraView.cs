using TMPro;
using UnityEngine;

public class QueSeraView : BaseView
{
    [SerializeField] private ButtonHelpher[] _buttons;
    [SerializeField] private TextMeshProUGUI _contentText;
    
    public override void Initialize()
    {
        base.Initialize();
        
        for (int i = 0; i < _buttons.Length; i++)
        {
            int i1 = i;
            //_buttons[i1].onClick.AddListener();
        }
    }

    public void SetContentText(string txt)
    {
        _contentText.text = txt;
    }

    public ButtonHelpher[] Helpers()
    {
        return _buttons;
    }
}