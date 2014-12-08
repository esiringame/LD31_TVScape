using UnityEngine;
using System.Collections;

public class HammerBehaviour : MonoBehaviour {

	public GameObject player;
	public GameObject screenScript;

	public int corner;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
			screenScript.GetComponent<ScreenScript>().Explode(corner);
	}
}
