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

    public Rigidbody2D body1;
    public Rigidbody2D body2;

    private Rigidbody2D _body;
    private Rigidbody2D _antiBody;

    void Start()
    {
        _input = new Vector2(0, 0);
        _newVel = new Vector2(0, 0);
        isJumping = false;

        _body = body1;
        _antiBody = body2;
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
	    if(_body == body1) {
		_body = body2;
                _antiBody = body1;
            }
	    else {
		_body = body1;
                _antiBody = body2;
            }
	    
        }

        _body.velocity = _newVel;
        _antiBody.velocity = new Vector2(-_newVel.x, -_newVel.y);
    }

    // void OnCollisionEnter(){
    // }

}
