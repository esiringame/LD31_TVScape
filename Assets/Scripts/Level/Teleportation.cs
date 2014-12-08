using UnityEngine;
using System.Collections;

public class Teleportation : MonoBehaviour {

	public GameObject target;
	private bool jump;
	public bool isActive;
	public AudioClip teleport_sound;

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (!jump) {
			
			if(!target.GetComponent<Teleportation>().isActive){
				target.GetComponent<Teleportation>().OnTriggerEnter2D(other);
			}else{
				target.GetComponent<Teleportation>().jump = true;
				// ###### Mise en place de l'audio du téléporteur ######
				audio.PlayOneShot(teleport_sound, 1.0F);
				// ###### FIN ######
				other.transform.position = target.transform.position + new Vector3(0,0.2f,0);
			}
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		jump = false;
		
	}
}