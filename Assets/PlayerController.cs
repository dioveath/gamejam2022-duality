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

    public CozzleCharacter cozzleCharacter1;
    public CozzleCharacter cozzleCharacter2;
    private bool isCharacterOneSelected = true;

    public Rigidbody2D body;
    public Rigidbody2D antiBody;
    public Animator animator;
    public Animator antiAnimator;

    public ParticleSystem _PSDust1;
    public ParticleSystem _PSDust2;

    private CozzleDirection _activeDirection;

    public bool _inputDisabled;

    void Start()
    {
        _input = new Vector2(0, 0);
        _newVel = new Vector2(0, 0);
        isJumping = false;

	cozzleCharacter1.SetControl(isCharacterOneSelected);
	cozzleCharacter2.SetControl(!isCharacterOneSelected);

        _inputDisabled = true;

        // _PSDust1 = cozzleCharacter1.GetComponent<ParticleSystem>();
        // _PSDust2 = cozzleCharacter2.GetComponent<ParticleSystem>();	
    }

    // Update is called once per frame
    void Update()
    {
	if(_inputDisabled) return;

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

            isCharacterOneSelected = !isCharacterOneSelected;
            cozzleCharacter1.SetControl(isCharacterOneSelected);
            cozzleCharacter2.SetControl(!isCharacterOneSelected);
        }

	// if(_newVel.x != 0 || _newVel.y != 0) {
        //     float gv = _newVel.x > _newVel.y ? _newVel.x : _newVel.y;
        //     transform.DOScale(new Vector3(gv / 8 * 0.1f, 1, 1), 0.5f).SetEase(Ease.InOutQuad);
        // } else {
        //     transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.InOutQuad);	    
	// }

        if(_newVel.x > 0) {
            animator.SetInteger("Direction", 2);
            antiAnimator.SetInteger("Direction", 3);

	    if(_activeDirection != CozzleDirection.RIGHT) {
                _PSDust1.Play();
                _PSDust2.Play();		
	    }
            _activeDirection = CozzleDirection.RIGHT;

        } else if(_newVel.x < 0){
            animator.SetInteger("Direction", 3);
            antiAnimator.SetInteger("Direction", 2);

	    if(_activeDirection != CozzleDirection.LEFT) {
                _PSDust1.Play();
                _PSDust2.Play();		
	    }
	    
            _activeDirection = CozzleDirection.LEFT;
	}

	if(_newVel.y > 0){
            animator.SetInteger("Direction", 1);
            antiAnimator.SetInteger("Direction", 0);

	    if(_activeDirection != CozzleDirection.TOP) {
                _PSDust1.Play();
                _PSDust2.Play();		
	    }
	    
            _activeDirection = CozzleDirection.TOP;	    
	} else if(_newVel.y < 0){

	    if(_activeDirection != CozzleDirection.BOTTOM) {
                _PSDust1.Play();
                _PSDust2.Play();		
	    }	    

            animator.SetInteger("Direction", 0);
            antiAnimator.SetInteger("Direction", 1);
            _activeDirection = CozzleDirection.BOTTOM;	    	    
	}


        body.velocity = _newVel;
        antiBody.velocity = new Vector2(-_newVel.x, -_newVel.y);
    }

    public void SetInputActive(bool active){
        _inputDisabled = !active;
    } 

}


public enum CozzleDirection {
    LEFT,
    TOP,
    RIGHT,
    BOTTOM
}
