using UnityEngine;
using System.Collections;

public class GhostBehaviour : MonoBehaviour {

	public float speed = 1.0f;
	public GameObject player;

	void Start () {

	}

	void Update () {

		float PosX = player.transform.position.x;
		if (PosX > this.transform.position.x) {
			transform.Translate (speed * Time.deltaTime, 0, 0);
		} 
		else if (PosX < this.transform.position.x) {
			transform.Translate (- speed * Time.deltaTime, 0, 0);
		}

		float PosY = player.transform.position.y;
		if (PosY > this.transform.position.y) {
			transform.Translate (0, speed * Time.deltaTime,0);
		}
		else if (PosY < this.transform.position.y) {
			transform.Translate (0, -speed * Time.deltaTime,0);
		}
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Player")
			player.GetComponent<PlayerMotor>().TakeDamage();
	}
	void onTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Player") {
			Physics2D.IgnoreCollision(this.collider2D,coll);
		}
	}

}
