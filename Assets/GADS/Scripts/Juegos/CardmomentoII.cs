using UnityEngine;
using UnityEngine.UI;

public class CardmomentoII : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _front;
    [SerializeField] private GameObject _back;
    [SerializeField] private bool _isFlip;
    [SerializeField] private MomentoIIContreoller _controller;
    [SerializeField] private bool canCall = true;


    private void FlipCard()
    {
        _isFlip = !_isFlip;
        _front.gameObject.SetActive(_isFlip);
        _back.gameObject.SetActive(!_isFlip);
        if (_controller != null && canCall)
        {
            canCall = false;
            _controller.CheckCards();
        }
    }

    public void Initialize(MomentoIIContreoller contreoller)
    {
        _controller = contreoller;
        
        _button = GetComponent<Button>();
        _button.interactable = true;
        _button.onClick.AddListener(() => FlipCard());
        
        _front.SetActive(false);
        _back.SetActive(true);
        _isFlip = false;
        canCall = true;
    }
}