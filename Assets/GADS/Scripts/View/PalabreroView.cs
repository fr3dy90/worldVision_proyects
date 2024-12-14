using UnityEngine;

public class PalabreroView : BaseView
{
    [SerializeField] private MyEnums.PalabreroI[] _emociones;

    public override void OnSetView()
    {
        base.OnSetView();
        Clear();
    }

    public void Clear()
    {
        foreach ( MyEnums.PalabreroI palabrero in _emociones)
        {
            palabrero.word.text = string.Empty;
            palabrero.wordII.text = string.Empty;
        }
    }

    public MyEnums.PalabreroI[] GetPalabrero()
    {
        return _emociones;
    }
}