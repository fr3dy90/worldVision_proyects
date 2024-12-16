using Cysharp.Threading.Tasks;
using UnityEngine;

public class MomentoIController : BaseController
{
    [SerializeField] private DialogueManager _dialogueManager;

    public override void Initialize()
    {
        _dialogueManager.OnComplete += OnCallMomentoIIContreoller;
        _dialogueManager.InitializeDialog(0);
    }


    public override void OnStart()
    {
        base.OnStart();
        OnStartDialog();
    }

    private async void OnStartDialog()
    {
        await UniTask.WaitForSeconds(1f);
        _dialogueManager.StartCurrentDialog(0);

    }

    private void OnCallMomentoIIContreoller()
    {
        _dialogueManager.OnComplete -= OnCallMomentoIIContreoller;
        GameManager.Instance.ChangeState(MyEnums.GameState.Momento_2);
    }

    
}