using UnityEngine;
using System.Collections;

public class SpawnHammer : MonoBehaviour {

	public GameObject prefab;
	public GameObject screenScript;

	public GameObject teleporterSW;
	public GameObject teleporterNW;
	public GameObject teleporterNE;
	public GameObject teleporterSE;

	public bool stillHammer;
	public int width;
	public int height;

	private float deltaHammer = 0;
	private float timerHammer = 20;

	// Use this for initialization
	void Start ()
	{
		deltaHammer = 0;
		stillHammer = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (stillHammer)
			return;

		deltaHammer += Time.deltaTime;
		if (deltaHammer >= timerHammer)
		{
			GameObject glass;
			int corner;
			do
			{
				corner = Random.Range(0,4);
				glass = screenScript.GetComponent<ScreenScript>().GetGlass(corner);
			} while (glass.GetComponent<SpriteRenderer>().enabled);

			Vector2 spawnPosition = centerPortionSpawn(corner);
			GameObject hammer = Instantiate(prefab, new Vector3 (spawnPosition.x, spawnPosition.y, 0), Quaternion.identity) as GameObject;
			hammer.GetComponent<HammerBehaviour>().corner = corner;
			hammer.GetComponent<HammerBehaviour>().screenScript = screenScript;
			hammer.GetComponent<HammerBehaviour>().spawnHammer = gameObject;

			stillHammer = true;
			deltaHammer -= timerHammer;
		}
	}

	Vector2 centerPortionSpawn (int corner)
	{
		Vector2 center = new Vector2(transform.position.x, transform.position.y);
		switch (corner)
		{
			case 0: return new Vector2(center.x - width/2, center.y + height/2); break;
			case 1: return new Vector2(center.x + width/2, center.y + height/2); break;
			case 2: return new Vector2(center.x - width/2, center.y - height/2); break;
			case 3: return new Vector2(center.x + width/2, center.y - height/2); break;
		}
		return Vector2.zero;
	}
}
