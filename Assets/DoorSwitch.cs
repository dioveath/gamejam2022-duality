using DG.Tweening;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{

    public Door door;
    public SwitchType switchType;

    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Entered");
        if(collider.tag == "Player" || collider.tag == "Player2") {
            transform.DOScale(new Vector3(1.05f, 0.96f, 1f), 0.1f).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                AudioManager.Instance().PlayAudio("switch_open");
                door.ActivateDoor();
            });
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        Debug.Log("OnExit");
        if(collider.tag == "Player" || collider.tag == "Player2") {
            transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
		if(switchType == SwitchType.Yoyo)
		    door.DeactivateDoor();		
            });
        }
    }

}

public enum SwitchType
{
    OneTime,
    Yoyo
}
