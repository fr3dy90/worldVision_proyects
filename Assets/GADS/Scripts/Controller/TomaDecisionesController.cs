using UnityEngine;
using UnityEngine.UI;

public class TomaDecisionesController : BaseController
{
    [SerializeField] private Button _homeButton;
    [SerializeField] private SelectableItem[] _selectableItems;
     [SerializeField] private int _totalInfo = 0;
    
    public override void Initialize()
    {
        base.Initialize();
        _totalInfo = 0;
        _homeButton.gameObject.SetActive(false);
        _homeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.ChangeState(MyEnums.GameState.Menu);
        });
        
        foreach (var t in _selectableItems)
        {
            t.SetController(this);
        }
    }

    public override void OnSetView()
    {
        base.OnSetView();
        foreach (SelectableItem selectableItem in _selectableItems)
        {
            selectableItem.OnResetInfo();
        }
    }

    public void OnSelect(MyEnums.SimpleDataStruct simpleDataStruct, bool isNewInfo)
    {
        if (_view is TomaDecisionesView view)
        {
            view.SetInfoScreen(simpleDataStruct);
        }

        if (isNewInfo)
        {
            _totalInfo++;
            if (_totalInfo == _selectableItems.Length)
            {
                _homeButton.gameObject.SetActive(true);
            }
        }
    }
}