using UnityEngine;
using System.Collections;
using System;

public class PlayerMotor : MonoBehaviour {

	//public Animator anim;
	public int life = 3;
	public float speed = 8;
	public float radiusGround = 0.3f;
	public int jump = 200;
	public Transform checkGround;
	public LayerMask Ground;

	private bool onGround = false;
	private float invicibility = invicibilityTime;
	private const int invicibilityTime = 2;
	public AudioClip jump_sound;
	public AudioClip damage_sound;

	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Jump") && onGround)
		{
			rigidbody2D.AddForce (new Vector2 (0, jump));
			// ###### Mise en place de l'audio du téléporteur ######
			audio.PlayOneShot(jump_sound, 1.0F);
			// ###### FIN ######
		}

		invicibility += Time.deltaTime;
		if (invicibility > invicibilityTime)
			invicibility = invicibilityTime;
	}

	void FixedUpdate()
	{
		float X = Input.GetAxis ("Horizontal");
		if (X != 0)
			transform.Translate (X * speed * Time.deltaTime,0,0);

		onGround = Physics2D.OverlapCircle (checkGround.position, radiusGround, Ground);
	}

	public void TakeDamage()
	{
		if (invicibility < invicibilityTime)
			return;

		// ###### Mise en place de l'audio du téléporteur ######
		audio.PlayOneShot(damage_sound, 1.0F);
		// ###### FIN ######

		if (life > 0)
			life--;

		invicibility = 0;
	}
}
