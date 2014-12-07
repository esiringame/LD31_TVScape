using UnityEngine;
using System.Collections;

// S'arrete tout seul parfois
public class ColorEnemy : MonoBehaviour
{
	//public Animator anim;
	public enum ColorType {Red, Green, Blue, Cyan, Magenta, Yellow};

	public GameObject Object;
	public ColorType color;
	public float moveSpeed;

	public LayerMask Wall;
	private bool onWall;
	public float radiusWall=0.1f;
	public Transform checkWallRight;
	public Transform checkWallLeft;

	float direction;
	bool visible;
	float push;
	
	void Awake ()
	{
		visible = true;
		direction = 1f;
		push =10f;
	}
	
	void Update ()
	{
		if(onWall)
		{
			flip ();
		}
			//anim.SetBool("Vsible",visible);
			//anim.SetBool("onWall",onWall);
			//anim.SetFloat("Direction",direction);
			transform.Translate(direction*moveSpeed*Time.deltaTime,0,0);

			visibility ();
	}

	void FixedUpdate() {
		onWall = Physics2D.OverlapCircle (checkWallRight.position, radiusWall, Wall) || Physics2D.OverlapCircle (checkWallLeft.position, radiusWall, Wall) ;
		//anim.SetBool("Wall", onWall);
	}


	void visibility() // Desaffiche quand on appuie sur le bon bouton
	{
		// Test input
		// Rouge, Magenta, Jaune
		if (Input.GetButtonDown ("Fire1") && color == ColorType.Red) {
			visible = !visible;
			transform.Translate(0,0,push);
			push *=-1;
			
		}
		else if (Input.GetButtonDown ("Fire1") && Input.GetButtonDown ("Fire2") && color == ColorType.Yellow) {
			visible = !visible;
			Object.SetActive(visible);
		}
		else if (Input.GetButtonDown ("Fire1") && Input.GetButtonDown ("Fire3") && color == ColorType.Magenta) {
			visible = !visible;
			Object.SetActive(visible);
		}
		
		//Vert, Cyan
		else if (Input.GetButtonDown ("Fire2") && color == ColorType.Green) {
			visible = !visible;
			Object.SetActive(visible);
			
		}
		else if (Input.GetButtonDown ("Fire2") && Input.GetButtonDown ("Fire3") && color == ColorType.Yellow) {
			visible = !visible;
			Object.SetActive(visible);
		}
		
		// Bleu
		else if (Input.GetButtonDown ("Fire3") && color == ColorType.Blue) {
			visible = !visible;
			Object.SetActive(visible);
		}
	}
	void flip() //demi tour, renversement de sprite
	{


		direction *= -1;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		this.transform.Translate (2*direction, 0, 0);
	}


				
	
}