using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float speed ;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			rigidbody2D.velocity = new Vector2(-speed, 0);
		}
		if(Input.GetKeyDown (KeyCode.RightArrow)){
			rigidbody2D.velocity = new Vector2(speed, 0);
		}
	}
}
