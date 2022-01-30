using DG.Tweening;
using UnityEngine;

public class Present : MonoBehaviour
{

    private bool isPlayerEntered1;
    private bool isPlayerEntered2;

    private AudioSource _audioSource;

    void Start(){
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider){
	if(collider.tag == "Player")
            isPlayerEntered1 = true;
	else if(collider.tag == "Player2")
	    isPlayerEntered2 = true;

	if(isPlayerEntered1 && isPlayerEntered2) {

            _audioSource.DOFade(0f, 2f).OnComplete(() =>
            {
                GameManager.Instance.OnWin();
            });


        }

    }

    void OnTriggerExit2D(Collider2D collider){
	if(collider.tag == "Player")
            isPlayerEntered1 = false;
	else if(collider.tag == "Player2")
            isPlayerEntered2 = false;
    }


}
