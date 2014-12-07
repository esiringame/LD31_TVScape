using UnityEngine;
using System.Collections;

public class SpawnFantomScript : MonoBehaviour {

	public GameObject playerInstance;
	public GameObject fantomInstance;
	public Vector2 center;
	public float length = 10;
	public float width = 10;

	private GameObject fantom;

	void Start () {
		Vector2 fantomSpawnPosition = centerPortionSpawn (playerInstance);
		fantom = Instantiate(fantomInstance, new Vector3 (fantomSpawnPosition.x, fantomSpawnPosition.y, 0), Quaternion.identity) as GameObject;
		fantom.GetComponent<FantomScript> ().player = playerInstance;
	}

	void Update () {
		//Vector2 fantomSpawnPosition = centerPortionSpawn (playerInstance);
		//fantom.velocity = transform.TransformDirection (fantomSpawnPosition.x, fantomSpawnPosition.y, 0);
	}

	//Le spawn du fantome est au centre du quart d'écran opposé à celui dans lequel est le joueur.
	Vector2 centerPortionSpawn (GameObject Player) {
		float PosX = playerInstance.transform.position.x;
		float PosY = playerInstance.transform.position.y;
		if (PosX > this.rigidbody2D.position.x) {
			if (PosY > this.rigidbody2D.position.y) {
				 return new Vector2(center.x - length/2, center.y - width/2);
				}
				else{ 
					return new Vector2(center.x - length/2, center.y + width/2);
				}
			}
		else {
			if (PosY > this.rigidbody2D.position.y) {
				return new Vector2(center.x - length/2, center.y - width/2);
			}
			else{ 
				return new Vector2(center.x - length/2, center.y + width/2);
			}
		}
	}
}
