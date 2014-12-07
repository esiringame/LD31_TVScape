using UnityEngine;
using System.Collections;

public class SpawnGhost : MonoBehaviour {

	public GameObject playerInstance;
	public GameObject fantomInstance;
	public Vector2 center;
	public float width = 10;
	public float height = 10;

	private GameObject fantom;
	private bool isActive = false;
	public AudioClip ghost_sound;

	void Start ()
	{
		isActive = false;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
		    isActive = !isActive;

			if (isActive)
			{
				Vector2 fantomSpawnPosition = centerPortionSpawn (playerInstance);
				// ###### Mise en place de l'audio du ghost ######
				audio.Play();
				// ###### FIN ######
				fantom = Instantiate(fantomInstance, new Vector3 (fantomSpawnPosition.x, fantomSpawnPosition.y, 0), Quaternion.identity) as GameObject;
				fantom.GetComponent<GhostBehaviour> ().player = playerInstance;
			}
			else
			{
				// ###### Mute du ghost ######
				audio.mute = true;
				// ###### FIN ######
				Destroy(fantom);
			}
		}
	}

	//Le spawn du fantome est au centre du quart d'écran opposé à celui dans lequel est le joueur.
	Vector2 centerPortionSpawn (GameObject Player) {
		float PosX = playerInstance.transform.position.x;
		float PosY = playerInstance.transform.position.y;
		if (PosX > transform.position.x) {
			if (PosY > transform.position.y) {
				 return new Vector2(center.x - width/2, center.y - height/2);
				}
				else{ 
					return new Vector2(center.x - width/2, center.y + height/2);
				}
			}
		else {
			if (PosY > transform.position.y) {
				return new Vector2(center.x + width/2, center.y - height/2);
			}
			else{ 
				return new Vector2(center.x + width/2, center.y + height/2);
			}
		}
	}
}
