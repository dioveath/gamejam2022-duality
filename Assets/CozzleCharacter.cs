using DG.Tweening;
using UnityEngine;

public class CozzleCharacter : MonoBehaviour
{

    public GameObject controlIndicator;
    public PlayerController controller;

    void Start(){
        // controlIndicator.SetActive(false);

        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 1f).SetEase(Ease.InBounce).OnComplete(() =>
        {
            transform.DOScale(new Vector3(1.01f, 1.04f, 1f), 0.5f).SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(0, 0.5f));
            controller.SetInputActive(true);
        });

    }

    public void SetControl(bool control){
        controlIndicator.SetActive(control);
    }

}
