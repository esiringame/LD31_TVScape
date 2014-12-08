using UnityEngine;
using System.Collections;
using System;

public class JukeBox : MonoBehaviour
{
	public float enemySight = 1.0f;
	public GameObject player;
	public Rigidbody2D crieur;

	public GameObject prefabOnde;

	public AudioSource music;

	private bool muteButton;
	private bool muteDistance;

	void Start ()
	{
		muteButton = false;
		muteDistance = false;

		GameObject onde = (GameObject)Instantiate(prefabOnde, transform.position, Quaternion.identity);
		onde.transform.parent = transform;
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
			muteButton = !muteButton;

		Vector2 posPlayer = new Vector2(player.transform.position.x, player.transform.position.y);
		Vector2 posCrieur = new Vector2(crieur.transform.position.x, crieur.transform.position.y);

		muteDistance = (posCrieur - posPlayer).magnitude > enemySight;

		music.mute = muteDistance || muteButton;
	}


}