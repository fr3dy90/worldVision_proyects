using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private ViewManager _viewManager;
    private Dictionary<MyEnums.GameState, BaseController> _dictionaryControllers = new ();
    [SerializeField] private MyEnums.GameState _currentGameState;
    [SerializeField] private BaseController[] _controllers;

    private const float FADE_DURATION = 0.5f;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _viewManager = GetComponent<ViewManager>();
        foreach (BaseController controller in _controllers)
        {
            controller.Initialize();
        }
        RegisterViewsAndControllers();
    }

    private void Start()
    {
        FadeManager.FadeIn(_dictionaryControllers[_currentGameState].GetView().GetCanvasGroup(), FADE_DURATION);
    }

    private void RegisterViewsAndControllers()
    {
        foreach (BaseController controller in  _controllers)
        {
            _dictionaryControllers[controller.GetState()] = controller;
            _viewManager.RegisterView(controller.GetState(), controller.GetView());
        }
    }

    public async UniTask ChangeState(MyEnums.GameState newState)
    {
        if (_currentGameState == newState) return;
        
        _dictionaryControllers[_currentGameState].GetView().IsInteractable(false);
        _dictionaryControllers[newState].GetView().IsInteractable(false);

        if (newState != MyEnums.GameState.Reflexion)
        {
            await FadeManager.Transition(_dictionaryControllers[_currentGameState].GetView().GetCanvasGroup(), _dictionaryControllers[newState].GetView().GetCanvasGroup(), FADE_DURATION, null);
            _viewManager.HideView(_currentGameState);
        }
        else
        {
            await FadeManager.FadeIn(_dictionaryControllers[newState].GetView().GetCanvasGroup(), FADE_DURATION);
        }
        
        _viewManager.ShowView(newState);
        _currentGameState = newState;
    }



    public void OnGameOver()
    {
    }
}
