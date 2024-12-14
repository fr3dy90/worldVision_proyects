using UnityEngine;

public class PalabreroController : BaseController
{
    [SerializeField, TextArea (3,3)] private string _reflexionPalabrero;

    public override void Initialize()
    {
        base.Initialize();
        if (_view is PalabreroView palabreroView)
        {
            foreach (MyEnums.PalabreroI palabreroI in palabreroView.GetPalabrero())
            {
                palabreroI.word.onEndEdit.AddListener(CheckFields);
                palabreroI.wordII.onEndEdit.AddListener(CheckFields);
            }
        }
    }

    void CheckFields(string t)
    {
        if (_view is PalabreroView palabreroView)
        {
            foreach (MyEnums.PalabreroI palabreroI in palabreroView.GetPalabrero())
            {
                if (string.IsNullOrEmpty(palabreroI.word.text) || string.IsNullOrWhiteSpace(palabreroI.word.text) ||
                    string.IsNullOrEmpty(palabreroI.wordII.text) || string.IsNullOrWhiteSpace(palabreroI.wordII.text))
                {
                    return;
                }
            }

            RefexionView.Instance.SetReflexionText(_reflexionPalabrero, _view.GetCanvasGroup());
        }
    }
}