using UnityEngine;

public class MomentoIIView : BaseView
{
    [SerializeField] private GameObject _panelNextScreen;


    public override void OnSetView()
    {
        base.OnSetView();
        ShowNextScreen(false);
    }

    public void ShowNextScreen(bool isActive)
    {
        _panelNextScreen.SetActive(isActive);
    } 

}