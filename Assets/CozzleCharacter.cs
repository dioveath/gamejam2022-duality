using DG.Tweening;
using UnityEngine;

public class CozzleCharacter : MonoBehaviour
{

    public GameObject controlIndicator;
    public PlayerController controller;

    void Start(){
        // controlIndicator.SetActive(false);

        transform.localScale = Vector3.zero;

        AudioManager.Instance().PlayAudio("player_spawn", 0.05f);
        transform.DOScale(Vector3.one, 1f).SetEase(Ease.InBounce).OnComplete(() =>
        {
            transform.DOScale(new Vector3(1.01f, 1.04f, 1f), 0.5f).SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(0, 0.5f));
            controller.SetInputActive(true);
        });

    }

    public void Shrink(float time = 1.0f){
        transform.DOScale(Vector3.zero, time).SetEase(Ease.OutBounce);
    }



    public void SetControl(bool control){
        controlIndicator.SetActive(control);
    }

}
