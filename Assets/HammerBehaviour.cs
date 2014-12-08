using UnityEngine;
using System.Collections;

public class HammerBehaviour : MonoBehaviour {

	public GameObject screenScript;
	public GameObject spawnHammer;
	public int corner;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			screenScript.GetComponent<ScreenScript>().Explode(corner);
			spawnHammer.GetComponent<SpawnHammer>().stillHammer = false;
			Destroy(gameObject);
		}
	}
}
