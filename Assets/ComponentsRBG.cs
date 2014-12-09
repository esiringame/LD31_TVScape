using UnityEngine;
using System.Collections;

public class ComponentsRBG : MonoBehaviour
{
	public bool redActive = true;
	public bool greenActive = true;
	public bool blueActive = true;

    public PanelControl pc;

	// Use this for initialization
	void Start ()
	{
		redActive = true;
		greenActive = true;
		blueActive = true;
        pc.setR(redActive);
        pc.setG(greenActive);
        pc.setB(blueActive);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) {
			redActive = !redActive;
            pc.setR(redActive);
        }
		if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) {
			greenActive = !greenActive;
            pc.setG(greenActive);
        }
		if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)) {
			blueActive = !blueActive;
            pc.setB(blueActive);
        }
	}
}
