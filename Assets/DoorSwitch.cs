using UnityEngine;

public class DoorSwitch : MonoBehaviour
{

    public Door door;
    public SwitchType switchType;

    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Entered");
        if(collider.tag == "Player" || collider.tag == "Player2") {
            door.ActivateDoor();
          }
    }

    void OnTriggerExit2D(Collider2D collider){
        Debug.Log("OnExit");
        if(collider.tag == "Player" || collider.tag == "Player2") {
	    if(switchType == SwitchType.Yoyo)
		door.DeactivateDoor();
        }
    }

}

public enum SwitchType
{
    OneTime,
    Yoyo
}
