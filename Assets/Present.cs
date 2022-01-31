using DG.Tweening;
using UnityEngine;

public class Present : MonoBehaviour
{

    private bool isPlayerEntered1;
    private bool isPlayerEntered2;

    private CozzleCharacter _tmpCharacter;

    private AudioSource _audioSource;

    private bool _activated = false;

    void Start(){
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider){
	if(collider.tag == "Player")
            isPlayerEntered1 = true;
	else if(collider.tag == "Player2")
	    isPlayerEntered2 = true;

	if(_tmpCharacter == null) _tmpCharacter = collider.GetComponent<CozzleCharacter>();

        if(isPlayerEntered1 && isPlayerEntered2 && !_activated) {
            _activated = true;

            collider.GetComponent<CozzleCharacter>().Shrink(2f);
            _tmpCharacter.Shrink(2f);

            AudioManager.Instance().PlayAudio("teleportation", 1f);
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

	if(_tmpCharacter != null) {
            _tmpCharacter = null;
        }

    }


}
