using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimate : MonoBehaviour
{

    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
        _text.DOFade(0.65f, 1f).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);
        transform.DOScale(0.95f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

}
