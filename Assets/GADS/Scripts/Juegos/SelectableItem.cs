using UnityEngine;
using UnityEngine.UI;

public class SelectableItem : MonoBehaviour
{
    [SerializeField] private Button _buttonSelectable;
    [SerializeField] private MyEnums.SimpleDataStruct _simpleDataStruct;
    [SerializeField] private TomaDecisionesController _tomaDecisionesController;
    [SerializeField] private bool _isNewInfo = true;

    public void SetController(TomaDecisionesController tomaDecisionesController)
    {
        _buttonSelectable = GetComponent<Button>();
        _tomaDecisionesController = tomaDecisionesController;
        _buttonSelectable.onClick.AddListener(OnSelect);
    }
    
    public void OnSelect()
    {
        _tomaDecisionesController.OnSelect(_simpleDataStruct, _isNewInfo);
        _isNewInfo = false;
    }

    public void OnResetInfo()
    {
        _isNewInfo = true;
    }
}