using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{

    // private BoxCollider2D collider;
    private bool _isLoading = false;
    private bool _isActive = false;

    void Start()
    {
        // collider = GetComponent<BoxCollider2D>();
        gameObject.SetActive(false);
    }

    public void ActivateDoor(){
	if(_isLoading || _isActive) return;

        _isLoading = true;

        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.InOutBounce).OnComplete(() => {
            _isLoading = false;
            _isActive = true;
            AudioManager.Instance().PlayAudio("box_spawn", 0.5f);
        });
    }

    public void DeactivateDoor(){
	if(_isLoading || !_isActive) return;

        _isLoading = true;

        transform.DOScale(Vector3.zero, 1f).SetEase(Ease.InOutBounce).OnComplete(() =>
        {
            _isLoading = false;
            _isActive = false;
	    gameObject.SetActive(false);
        });
    }

}
