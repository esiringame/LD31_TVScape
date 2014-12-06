using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public Animator anim;
	public float speed = 8.0f;

	public Transform checkGround;
	private bool onGround = false;
	public float radiusGround = 0.3f;
	public int jump = 200;
	public LayerMask Ground;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float X = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump") && onGround) {
			rigidbody2D.AddForce(new Vector2(0,jump));
				}

		if (X != 0) {
						transform.Translate (X * speed * Time.deltaTime,0,0);
				}
	}

	void FixedUpdate() {
		onGround = Physics2D.OverlapCircle (checkGround.position, radiusGround, Ground);
		anim.SetBool("Ground", onGround);
	}

}
