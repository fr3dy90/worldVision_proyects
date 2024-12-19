using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TomaDecisionesView : BaseView
{
    [SerializeField] private CanvasGroup _canvasGroupInfo;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _paragraph;
    [SerializeField] private Button _buttonClose;
    
    public override void Initialize()
    {
        base.Initialize();
        _buttonClose.onClick.AddListener(() => HandleFade(false));
    }
    
    public override void OnSetView()
    {
        base.OnSetView();
        handleScreen(false);
    }

    public void handleScreen(bool isActive)
    {
        _canvasGroupInfo.alpha = isActive ? 1 : 0;
        _canvasGroupInfo.interactable = isActive;
        _canvasGroupInfo.blocksRaycasts = isActive;
    }

    public void SetInfoScreen(MyEnums.SimpleDataStruct simpleDataStruct)
    {
        _title.text = simpleDataStruct.Title;
        _paragraph.text = simpleDataStruct.Paragraph;
        HandleFade(true);
    }

    public async void HandleFade(bool isFadeIn)
    {
        if (isFadeIn)
        {
            await FadeManager.FadeInCanvas(_canvasGroupInfo, 0.5f);
            handleScreen(true);
        }
        else
        {
            await FadeManager.FadeOut(_canvasGroupInfo, 0.5f);
            handleScreen(false);
        }
    }
}