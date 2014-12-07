using UnityEngine;
using System.Collections;
using System;

public class JukeBox : MonoBehaviour
{
	public float enemySight = 20.0f;
	public Rigidbody2D player;
	public Rigidbody2D crieur;
	public AudioSource music;

	bool muet;

	void Start ()
	{
		music.mute = true;
		muet = false;
	}
	void Update ()
	{
		if(Input.GetButtonDown("Jump")){
			muet = !muet;
		   music.mute = !music.mute;
		}
		if (Math.Abs(player.position.x) <= Math.Abs(crieur.position.x + enemySight) && Math.Abs(player.position.y) <= Math.Abs(crieur.position.y+enemySight) && !muet) {
						music.mute = false;
				}
		else {
		
						music.mute = true;
				}
	}
}