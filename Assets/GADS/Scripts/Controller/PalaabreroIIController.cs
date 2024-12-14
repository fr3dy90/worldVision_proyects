using UnityEngine;

public class PalaabreroIIController: BaseController
{

    public override void Initialize()
    {
        base.Initialize();
        if (_view is PalabreroIIView view)
        {
            foreach (MyEnums.PalabreroII palabreroII in view.GetPalabreroII())
            {
                palabreroII.button.onClick.AddListener(CheckEmociones);
                palabreroII.buttonII.onClick.AddListener(CheckEmociones);
            }
        }
    }

    void CheckEmociones()
    {
        if(_view is PalabreroIIView view)
        {
            foreach (MyEnums.PalabreroII palabreroII in view.GetPalabreroII())
            {
                if (!palabreroII.isAnswered)
                {
                    return;
                }
            }
            
            GameManager.Instance.ChangeState(MyEnums.GameState.Menu);
        }
    }
}