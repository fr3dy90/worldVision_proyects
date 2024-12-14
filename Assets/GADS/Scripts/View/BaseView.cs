using UnityEngine;

public abstract class BaseView : MonoBehaviour, IView
{
    protected CanvasGroup _canvasGroup;

    public virtual void OnSetView()
    {
        _canvasGroup.alpha = 0;
    }

    public virtual void Initialize()
    {
        if (_canvasGroup == null)
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        
        Hide();
    }

    public void IsInteractable(bool isInteractable)
    {
        _canvasGroup.interactable = isInteractable;
        _canvasGroup.blocksRaycasts = isInteractable;
    }

    public CanvasGroup GetCanvasGroup()
    {
        return _canvasGroup;
    }

    public virtual void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
    }

    public virtual void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }
    
    
    
}
