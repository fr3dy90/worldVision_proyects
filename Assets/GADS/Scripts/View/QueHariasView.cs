using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QueHariasView : BaseView
{
     [SerializeField] private TextMeshProUGUI _situacionText;
     [SerializeField] private TextMeshProUGUI _optionI;
     [SerializeField] private TextMeshProUGUI _optionII;

     public Button _buttonI;
     public Button _buttonII; 
     
     [SerializeField] private MyEnums.QueHariasStruct[] _queHarias;

     public override void Initialize()
     {
          base.Initialize();
          Settext(0);
     }

     public void Settext(int index)
     {
          _situacionText.text = _queHarias[index].Situacion;
          _optionI.text = _queHarias[index].optionI;
          _optionII.text = _queHarias[index].optionII;
     }
     
     public MyEnums.QueHariasStruct[] GetQueHarias()
     {
          return _queHarias;
     }
}