using UnityEngine;

public class Door : MonoBehaviour
{

    // private BoxCollider2D collider;

    void Start()
    {
        // collider = GetComponent<BoxCollider2D>();
        gameObject.SetActive(false);
    }

    public void ActivateDoor(){
        // collider.isTrigger = false;
        gameObject.SetActive(true);
    }

    public void DeactivateDoor(){
        // collider.isTrigger = true;
	gameObject.SetActive(false);
    }

}
