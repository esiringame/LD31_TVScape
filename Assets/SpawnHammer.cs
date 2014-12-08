using UnityEngine;
using System.Collections;

public class SpawnHammer : MonoBehaviour {

	public GameObject prefab;
	public GameObject screenScript;

	private float deltaHammer = 0;
	private float timerHammer = 20;

	// Use this for initialization
	void Start ()
	{
		deltaHammer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		deltaHammer += Time.deltaTime;
		if (deltaHammer >= timerHammer)
		{
			GameObject glass;
			int corner;
			do
			{
				corner = Random.Range(0,4);
				glass = screenScript.GetComponent<ScreenScript>().GetGlass(corner);
			} while (!glass.GetComponent<SpriteRenderer>().enabled);
			GameObject colored = Instantiate(prefab, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;

			deltaHammer -= timerHammer;
		}
	}
}
