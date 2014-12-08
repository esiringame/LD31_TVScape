using UnityEngine;
using System.Collections;

public class Control2 : MonoBehaviour {
	
	public float speed ;
	private bool ammo =false;

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			rigidbody2D.velocity = new Vector2(-speed, 0);
		}
		if(Input.GetKeyDown (KeyCode.RightArrow)){
			rigidbody2D.velocity = new Vector2(speed, 0);
			

		}

		if(Input.GetKeyDown(KeyCode.Space)){
			if(ammo){
				GameObject[] gO = GameObject.FindGameObjectsWithTag ("Enemy");
				for(var i = 0 ; i < gO.Length ; i ++){
					Destroy(gO[i]);
				}
				ammo=false;
				audio.Play();
				GameObject[] cam=GameObject.FindGameObjectsWithTag ("MainCamera");
				cam[0].GetComponent<Camera>().enabled=false;
				StartCoroutine(comBackScreen(cam[0]));
			}

		}
	}

	IEnumerator comBackScreen(GameObject go){
		yield return new WaitForSeconds(2);
		audio.Play();
		go.GetComponent<Camera>().enabled=true;

	}
	public void addAmmo(){
		ammo = true;
	}
}
