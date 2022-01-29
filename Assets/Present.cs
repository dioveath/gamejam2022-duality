using UnityEngine;
using UnityEngine.Events;

public class Present : MonoBehaviour
{

    private bool isPlayerEntered1;
    private bool isPlayerEntered2;

    public UnityEvent onWinEvent = new UnityEvent();

    void Start(){
    }

    void OnTriggerEnter2D(Collider2D collider){
	if(collider.tag == "Player")
            isPlayerEntered1 = true;
	else if(collider.tag == "Player2")
	    isPlayerEntered2 = true;

	if(isPlayerEntered1 && isPlayerEntered2) {
            Debug.Log("...");
            onWinEvent?.Invoke();
        }

    }


    void OnTriggerExit2D(Collider2D collider){
	if(collider.tag == "Player")
            isPlayerEntered1 = false;
	else if(collider.tag == "Player2")
            isPlayerEntered2 = false;
    }

}
