using UnityEngine;
using System.Collections;
using System;

public class JukeBox : MonoBehaviour
{
	public float enemySight = 1.0f;
	public GameObject player;
	public Rigidbody2D crieur;

	public GameObject prefabOnde;
	public int Force = 120;

	public AudioSource music;

	private bool muteButton;
	private bool muteDistance;
	private Vector2 directionForce;
	private GameObject onde;

	void Start ()
	{
		muteButton = false;
		muteDistance = false;

		onde = (GameObject)Instantiate(prefabOnde, transform.position, Quaternion.identity);
		onde.transform.parent = transform;
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
			muteButton = !muteButton;

		Vector2 posPlayer = new Vector2(player.transform.position.x, player.transform.position.y);
		Vector2 posCrieur = new Vector2(crieur.transform.position.x, crieur.transform.position.y);

		muteDistance = (posCrieur - posPlayer).magnitude > enemySight;
		directionForce = (posCrieur - posPlayer);

		music.mute = muteDistance || muteButton;
	}

	void FixedUpdate () {
		if (muteButton) {
			onde.SetActive(false);
		} else {
			onde.SetActive(true);
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if(collider.gameObject.tag == "Player") {

			if(muteButton){
				Physics2D.IgnoreCollision(this.collider2D,collider,true);
			}else{
				Physics2D.IgnoreCollision(this.collider2D,collider,false);
				onde.SetActive(true);
			}

			Vector2 posPlayer = new Vector2(player.transform.position.x, player.transform.position.y);
			Vector2 posCrieur = new Vector2(crieur.transform.position.x, crieur.transform.position.y);

			directionForce = (-posCrieur + posPlayer);
			if (!muteButton) {player.rigidbody2D.AddForceAtPosition(directionForce*Force, posCrieur);}
		}
	}

	void OnTriggerStay2D (Collider2D collider) {
		if(collider.gameObject.tag == "Player") {

			if(muteButton){
				Physics2D.IgnoreCollision(this.collider2D,collider,true);
			}else{
				Physics2D.IgnoreCollision(this.collider2D,collider,false);
				onde.SetActive(true);
			}

			Vector2 posCrieur = new Vector2(crieur.transform.position.x, crieur.transform.position.y);
			Vector2 directionForce = new Vector2(1, 1);

			if (!muteButton) {player.rigidbody2D.AddForceAtPosition(directionForce*Force/2, posCrieur);}
		}
	}

}