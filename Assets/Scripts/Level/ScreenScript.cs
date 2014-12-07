using UnityEngine;
using System.Collections;

public class ScreenScript : MonoBehaviour {

    public GameObject glassScreen0;
    public GameObject glassScreen1;
    public GameObject glassScreen2;
    public GameObject glassScreen3;
    public GameObject blankScreen;

	// Use this for initialization
	void Start () {
        glassScreen0.GetComponent<SpriteRenderer>().enabled = false;
        glassScreen1.GetComponent<SpriteRenderer>().enabled = false;
        glassScreen2.GetComponent<SpriteRenderer>().enabled = false;
        glassScreen3.GetComponent<SpriteRenderer>().enabled = false;
        blankScreen.GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
