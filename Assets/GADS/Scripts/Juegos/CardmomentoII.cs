using UnityEngine;

public class CardmomentoII : MonoBehaviour
{
    [SerializeField] private GameObject _front;
    [SerializeField] private GameObject _back;
    [SerializeField] private bool _isFlip;

    public void FlipCard()
    {
        _isFlip = !_isFlip;
        _front.gameObject.SetActive(_isFlip);
        _back.gameObject.SetActive(!_isFlip);
    }
}