using UnityEngine;
using System.Collections;

// S'arrete tout seul parfois
public class ColoredBehaviour : MonoBehaviour
{
	//public Animator anim;
	public enum ColorType {Red = 0, Green = 1, Blue = 2, Yellow = 3, Magenta = 4, Cyan = 5};

	public GameObject prefab;
	public GameObject player;

	public ColorType color;
	public float moveSpeed;

	public LayerMask Wall;
	private bool onWall;
	public float radiusWall=0.1f;
	public Transform checkWallRight;
	public Transform checkWallLeft;

	public GameObject componentsRGB;
	
	private float direction;
	private bool visible;

	
	void Awake ()
	{
		visible = true;
		direction = Random.Range(0.0f, 2.0f) - 1.0f;
		onWall = false;
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
		onWall = false;
		//onWall = Physics2D.OverlapCircle (checkWallRight.position, radiusWall, Wall)
		//	|| Physics2D.OverlapCircle (checkWallLeft.position, radiusWall, Wall);
		//anim.SetBool("Wall", onWall);
	}


	void visibility() // Desaffiche quand on appuie sur le bon bouton
	{
		bool red = componentsRGB.GetComponent<ComponentsRBG>().redActive;
		bool green = componentsRGB.GetComponent<ComponentsRBG>().greenActive;
		bool blue = componentsRGB.GetComponent<ComponentsRBG>().blueActive;

		switch (color)
		{
		case ColorType.Red: visible = red; break;
		case ColorType.Green: visible = green; break;
		case ColorType.Blue: visible = blue; break;
		case ColorType.Yellow: visible = red && green; break;
		case ColorType.Magenta: visible = red && blue; break;
		case ColorType.Cyan: visible = green && blue; break;
		}

		gameObject.SetActive(visible);
	}

	void flip() //demi tour, renversement de sprite
	{
		direction *= -1;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		transform.Translate(direction*0.5f, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Player") {
			Physics2D.IgnoreCollision(this.collider2D,coll);
		}

	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Player")
			player.GetComponent<PlayerMotor>().TakeDamage();
	}
}