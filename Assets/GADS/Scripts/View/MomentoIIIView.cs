using TMPro;
using UnityEngine;

public class MomentoIIIView : BaseView
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _optionI;
    [SerializeField] private TextMeshProUGUI _optionII;

    public override void OnSetView()
    {
        base.OnSetView();
    }

    public void SetTexts(MyEnums.BasicDataStruct dataStruct)
    {
        _title.text = dataStruct.MainQuest;
        _optionI.text = dataStruct.OptionI;
        _optionII.text = dataStruct.OptionII;
    }
    
   
}