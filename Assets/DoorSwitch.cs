using System;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{

    public Door door;

    void Start()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision){
        Collider2D collider = collision.collider;

        if(collider.tag == "Player") {
            for (int i = 0; i < collision.contacts.Length; i++){
                Vector2 contactPoint = collision.contacts[i].point;
                Vector2 min = collider.bounds.min;
		Vector2 max = collider.bounds.max;

//                 Debug.Log("ContactPoint: " + contactPoint);
//                 Debug.Log("Min.x: " + Math.Round(min.x) + "MaxX: " + Math.Round(max.x));
//
//                 Debug.DrawLine(contactPoint, new Vector2(0, 0), Color.red, 5f);
// 		Debug.DrawLine(min, new Vector2(0, 0), Color.blue, 5f);
// 		Debug.DrawLine(max, new Vector2(0, 0), Color.green, 5f);	    	    

		if(contactPoint.x >= Math.Round(min.x) && contactPoint.x <= Math.Round(max.x)) {
		    if(contactPoint.y >= Math.Round(min.y)){ // verticall collided
			Debug.Log("Welcome to the good night!");
                        break;
                    }
		}		
	    }
        }

    }


}
