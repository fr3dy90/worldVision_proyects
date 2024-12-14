using UnityEngine;
using UnityEngine.EventSystems;

public class LetterSender : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AhorcadoController _controller;
    [SerializeField] private char _letter;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _controller.GuessLetter(_letter);
    }
}