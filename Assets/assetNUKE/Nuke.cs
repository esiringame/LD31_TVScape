using UnityEngine;
using System.Collections;

public class Nuke : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag== ("Player")) {
			Destroy (this.gameObject);
			other.GetComponent<PlayerMotor> ().addAmmo ();
		}
	}

}
