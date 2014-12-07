using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	//Points de vie

	public int hp = 3;
	bool isDead = false;
	
	void OnTriggerEnter2D(Collider2D collider) {
		hp -= 1;
		if (hp <= 0) {
						Destroy (gameObject);
						isDead = true;
				}
	}

	//Marche pas
	void OnCollisionEnter2D(Collision2D collider){
		if( collider.gameObject.name =="ColorEnemy"){
			hp -= 1;
		}
		
		if (hp <=0){
			Destroy(gameObject);
			isDead = true;
		}
		}


}
