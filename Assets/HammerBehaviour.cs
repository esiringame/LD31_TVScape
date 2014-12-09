using UnityEngine;
using System.Collections;

public class HammerBehaviour : MonoBehaviour {

	public GameObject screenScript;
	public GameObject spawnHammer;
	
	public GameObject teleporterSW;
	public GameObject teleporterNW;
	public GameObject teleporterNE;
	public GameObject teleporterSE;

	public int corner;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			screenScript.GetComponent<ScreenScript>().Explode(corner);
			spawnHammer.GetComponent<SpawnHammer>().stillHammer = false;

			switch (corner)
			{
			case 0: teleporterNE.GetComponent<Teleportation>().isActive = false; break;
			case 1: teleporterNW.GetComponent<Teleportation>().isActive = false; break;
			case 2: teleporterSE.GetComponent<Teleportation>().isActive = false; break;
			case 3: teleporterSW.GetComponent<Teleportation>().isActive = false; break;
			}

			Destroy(gameObject);
		}
	}
}
