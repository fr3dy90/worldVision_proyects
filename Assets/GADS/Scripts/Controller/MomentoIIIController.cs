using UnityEngine;
using UnityEngine.UI;

public class MomentoIIIController : BaseController
{
    [SerializeField] private DataModelQuest _dataModelQuest;
    [SerializeField] private Button optionI;
    [SerializeField] private Button optionII;
    [SerializeField] private int index = 0;
    
    public override void Initialize()
    {
        optionI.onClick.AddListener(NextSituation);
        optionII.onClick.AddListener(NextSituation);
        base.Initialize();
    }
    
    override public void OnSetView()
    {
        base.OnSetView();

        index = 0;
        if (_view is MomentoIIIView view)
        {
            view.SetTexts(_dataModelQuest.dataStructs[index]);
        }
    }

    public void NextSituation()
    {
        index++;
        if (index < _dataModelQuest.dataStructs.Length)
        {
            if (_view is MomentoIIIView view)
            {
                view.SetTexts(_dataModelQuest.dataStructs[index]);
            }
        }
        else
        {
            GameManager.Instance.ChangeState(MyEnums.GameState.Menu);
        }
    }
}