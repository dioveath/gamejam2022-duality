using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Player player;
    public float speed;
    public float jumpHeight = 8f;

    public bool isJumping { get; private set; }

    private Vector2 _input;
    private Vector2 _newVel;

    public Rigidbody2D body;
    public Rigidbody2D antiBody;
    public Animator animator;
    public Animator antiAnimator;

    void Start()
    {
        _input = new Vector2(0, 0);
        _newVel = new Vector2(0, 0);
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");

        _newVel.x = _input.x * speed * Time.fixedDeltaTime;
        _newVel.y = _input.y * speed * Time.fixedDeltaTime;

        if(Input.GetKeyDown("space")) {
            _newVel.y = (float) Math.Sqrt(-2 * Physics2D.gravity.y * jumpHeight);
            // Debug.Log("Physics2D.gravity.y: " + Physics2D.gravity.y);
            isJumping = true;
        }

	if(Input.GetKeyDown("q")){
	    Animator tmpAnimator;
	    tmpAnimator = animator;
	    animator = antiAnimator;
	    antiAnimator = tmpAnimator;

            Rigidbody2D tmpBody;
            tmpBody = body;
            body = antiBody;
            antiBody = tmpBody;	    
        }




        if(_newVel.x > 0) {
            animator.SetInteger("Direction", 2);
            antiAnimator.SetInteger("Direction", 3);
        } else if(_newVel.x < 0){
            animator.SetInteger("Direction", 3);
            antiAnimator.SetInteger("Direction", 2);
	}

	if(_newVel.y > 0){
            animator.SetInteger("Direction", 1);
            antiAnimator.SetInteger("Direction", 0);	    
	} else if(_newVel.y < 0){
            animator.SetInteger("Direction", 0);
            antiAnimator.SetInteger("Direction", 1);	    	    
	}

        body.velocity = _newVel;
        antiBody.velocity = new Vector2(-_newVel.x, -_newVel.y);
    }

    // void OnCollisionEnter(){
    // }

}
