using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class ConcentreseController : BaseController
{
    [SerializeField] private List<Card >_cards;
    [SerializeField] private List<Card> _flippedCards; 
    
    [SerializeField, TextArea(3,3)] private string _reflexionConcentrese;
    
    void Start()
    {
        _flippedCards = new List<Card>();
    }

    public override void OnSetView()
    {
        base.OnSetView();
        System.Random random = new System.Random();
        _cards = _cards.OrderBy(x => random.Next()).ToList();
        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].transform.SetSiblingIndex(i);
        }
    }

    public void OnCardClicked(Card card)
    {
        if (_flippedCards.Count < 2 && !card.IsFlipped)
        {
            card.FlipCard();
            _flippedCards.Add(card);

            if (_flippedCards.Count == 2)
            {
                CheckForPair();
            }
        }
    }

    private void CheckForPair()
    {
        if (_flippedCards[0].cardId == _flippedCards[1].cardId)
        {
            _flippedCards.Clear();
        }
        else
        {
            Invoke("FlipBack", 1);
        }
    }

    private void FlipBack()
    {
        _flippedCards[0].FlipCard();
        _flippedCards[1].FlipCard();
        _flippedCards.Clear();
    }
}