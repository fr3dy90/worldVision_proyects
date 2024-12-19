using UnityEngine;
using UnityEngine.UI;

public class MomentoIIContreoller : BaseController
{
   [SerializeField] private CardmomentoII[] _cards;
   [SerializeField] private int cardsChecked = 0;
    [ SerializeField] private Button _buttonNextScreen;
   
   public override void Initialize()
   {
      base.Initialize();
      cardsChecked = 0;
      _buttonNextScreen.onClick.AddListener(NextScreen);
   }

   public override void OnSetView()
   {
      base.OnSetView();
      foreach (CardmomentoII card in _cards)
      {
         card.Initialize(this);
      }
   }

   public void CheckCards()
   {
      cardsChecked++;
      if (cardsChecked == _cards.Length)
      {
         foreach (CardmomentoII card in _cards)
         {
            card.GetComponent<Button>().interactable = false;
         }

         if (_view is MomentoIIView view)
         {
            view.ShowNextScreen(true);
         }
      }
   }
   
   private void NextScreen()
   {
      GameManager.Instance.ChangeState(MyEnums.GameState.Momento_3);
   }
}