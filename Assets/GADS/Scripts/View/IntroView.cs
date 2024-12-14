using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IntroView : BaseView
{
    [SerializeField] private Button _continueButton;

    public override void Initialize()
    {
        base.Initialize();
    }

    public void SetButton(UnityAction onClic)
    {
        _continueButton.onClick.AddListener(onClic);
    }
}
