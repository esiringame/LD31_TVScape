using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

	//public Animator anim;
	public int life = 3;
	public float speed = 8.0f;
	public float radiusGround = 0.3f;
	public int jump = 200;
	public Transform checkGround;
	public LayerMask Ground;

	private bool onGround = false;
	private float invicibility = invicibilityTime;
	private const int invicibilityTime = 2;

	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float X = Input.GetAxis ("Horizontal");
		
		if (X != 0)
			transform.Translate (X * speed * Time.deltaTime,0,0);

		if (Input.GetButtonDown ("Jump") && onGround)
			rigidbody2D.AddForce(new Vector2(0,jump));

		invicibility += Time.deltaTime;
		if (invicibility > invicibilityTime)
			invicibility = invicibilityTime;
	}

	void FixedUpdate()
	{
		onGround = Physics2D.OverlapCircle (checkGround.position, radiusGround, Ground);
	}

	public void TakeDamage()
	{
		if (invicibility < invicibilityTime)
			return;

		if (life > 0)
			life--;

		invicibility = 0;
	}
}
