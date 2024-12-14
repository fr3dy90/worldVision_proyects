using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RefexionView : BaseView
{
    public static RefexionView Instance;
    
    [SerializeField] private Button _buttonClose;
    [SerializeField] private TextMeshProUGUI _reflexionText;
    [SerializeField] private CanvasGroup _previosCanvasGroup;

    public override void Initialize()
    {
        base.Initialize();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        _buttonClose.onClick.AddListener( () => CallMenu() );
    }

    public async UniTask CallMenu()
    {
        FadeManager.FadeOut(_previosCanvasGroup, 0.5f);
        await GameManager.Instance.ChangeState(MyEnums.GameState.Menu);
    }
    
    public async void SetReflexionText(string text, CanvasGroup previosCanvasGroup)
    {
        _previosCanvasGroup = previosCanvasGroup;
        _reflexionText.text = text;
        await GameManager.Instance.ChangeState(MyEnums.GameState.Reflexion);
    }
}