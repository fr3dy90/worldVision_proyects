using UnityEngine;

public class ButtonHelpher : MonoBehaviour
{
    public MyEnums.GameState _buttonState;
    public MyEnums.Emocion _buttonEmocion;

    public void SetState()
    {
        GameManager.Instance.ChangeState(_buttonState);
    }

    public MyEnums.Emocion SetEmocion()
    {
        return _buttonEmocion;
    }
}