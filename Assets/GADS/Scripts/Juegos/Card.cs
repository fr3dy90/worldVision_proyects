using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool _isText;
    [SerializeField] private TextMeshProUGUI _textCard;
    [SerializeField] private Image _front;
    [SerializeField] private Image _back;
    [SerializeField] private bool _isFlipped = false;

    [SerializeField] private ConcentreseController _concentreseController;

    private GameObject _gameObjectFront;
    public string cardId;
    
    public bool IsFlipped => _isFlipped;

    private void Awake()
    {
        _textCard.text = cardId;
        _front.gameObject.SetActive(false);
        _textCard.gameObject.SetActive(false);
        _gameObjectFront = _isText ? _textCard.gameObject : _front.gameObject;
        _gameObjectFront.SetActive(_isFlipped);
        _back.gameObject.SetActive(!_isFlipped);
    }
    
    public void FlipCard()
    {
        _isFlipped = !_isFlipped;
        _gameObjectFront.SetActive(_isFlipped);
        _back.gameObject.SetActive(!_isFlipped);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _concentreseController.OnCardClicked(this);
    }
}