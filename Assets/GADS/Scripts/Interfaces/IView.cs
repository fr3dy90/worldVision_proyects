using UnityEngine;

public interface IView
{
    void Show();
    void Hide();

    void OnSetView();
    
    void Initialize();

    void IsInteractable(bool isInteractable);
    
    CanvasGroup GetCanvasGroup();
}
