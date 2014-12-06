using UnityEngine;
using System.Collections;

public class FantomScript : MonoBehaviour {

	public float speed = 1.0f;
	public Rigidbody2D player;

	void Start () {
	
	}

	void Update () {

		float PosX = player.position.x;
		if (PosX > rigidbody2D.position.x) {
						transform.Translate (speed * Time.deltaTime, 0, 0);
				} 
		else if (PosX < rigidbody2D.position.x) {
						transform.Translate (- speed * Time.deltaTime, 0, 0);
				}

		float PosY = player.position.y;
		if (PosY > rigidbody2D.position.y) {
			transform.Translate (0, speed * Time.deltaTime,0);
		}
		else if (PosY < rigidbody2D.position.y) {
			transform.Translate (0, -speed * Time.deltaTime,0);
		}
	}
}
