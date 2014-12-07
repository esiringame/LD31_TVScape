using UnityEngine;
using System.Collections;

public class Teleportation : MonoBehaviour {

	public GameObject target;
	private bool jump;
	public bool isActive;

	public void OnTriggerEnter2D(Collider2D other)
	{
		audio.Play ();
		if (!jump) {
			
			if(!target.GetComponent<Teleportation>().isActive){
				target.GetComponent<Teleportation>().OnTriggerEnter2D(other);
			}else{
				target.GetComponent<Teleportation>().jump = true;
				other.transform.position = target.transform.position;
			}
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		jump = false;
		
	}
}