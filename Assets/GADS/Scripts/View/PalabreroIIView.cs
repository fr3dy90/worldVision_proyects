using System;
using UnityEngine;

public class PalabreroIIView : BaseView
{
     [SerializeField] private MyEnums.PalabreroII[] _emociones;

     public override void Initialize()
     {
          base.Initialize();
          for (int i = 0; i < _emociones.Length; i++)
          {
               int i1 = i;
               _emociones[i1].button.interactable = true;
               _emociones[i1].buttonII.interactable = true;
               _emociones[i1].isAnswered = false;
               
               _emociones[i1].button.onClick.AddListener(() =>
               {
                    _emociones[i1].buttonII.gameObject.SetActive(false);
                    _emociones[i1].button.interactable = false;
                    _emociones[i1] .isAnswered = true;
               });
               
               _emociones[i1].buttonII.onClick.AddListener(() =>
               {
                    _emociones[i1].button.gameObject.SetActive(false); 
                    _emociones[i1].buttonII.interactable = false;
                    _emociones[i1] .isAnswered = true;
               });
          }
     }

     public MyEnums.PalabreroII[] GetPalabreroII()
     {
          return _emociones;
     }
}