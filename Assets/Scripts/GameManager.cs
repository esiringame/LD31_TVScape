using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public enum GameState
	{
		Menu,
		Playing,
		Pause,
		GameOver,
		Victory
	}
	
	public GameState state;
	private GameState lastState;

	public GameObject PauseScreen;
	public GameObject GameOverScreen;
	public GameObject ScreenScript;
	public GameObject player;

	public GameObject Home;
	public GameObject Tutorial1;
	public GameObject Tutorial2;
	public GameObject Tutorial3;
	public GameObject Tutorial4;
	public GameObject Tutorial5;
	
	private float timeScore;
	private int tutorialState = 0;

    public bool waitActive;

	Animator anim;

	private bool pause
	{
		set { Time.timeScale = value ? 0.0f : 1.0f; }
	}

	// Use this for initialization
	void Start ()
	{
		anim = GameOverScreen.GetComponent<Animator>();
		anim.enabled = false;
		state = GameState.Menu;
		timeScore = 0;
		tutorialState = 0;

		pause = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (state)
		{

		case GameState.Menu:
			
			if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
			{
				tutorialState++;
				switch (tutorialState)
				{
				case 1: Home.transform.position = new Vector3(0,0,-10); break;
				case 2: Tutorial1.transform.position = new Vector3(0,0,-10); break;
				case 3: Tutorial2.transform.position = new Vector3(0,0,-10); break;
				case 4: Tutorial3.transform.position = new Vector3(0,0,-10); break;
				case 5: Tutorial4.transform.position = new Vector3(0,0,-10); break;
				case 6:
					Tutorial5.transform.position = new Vector3(0,0,-10);
					state = GameState.Playing;
					pause = false;
					break;
				}
			}
			
			break;

		case GameState.Playing:
			
			if (ScreenScript.GetComponent<ScreenScript>().totallyExplode)
			{
				Victory();
			}
			else if (player.GetComponent<PlayerMotor>().life <= 0)
			{
				GameOver();
			}
			else if (Input.GetKeyDown(KeyCode.Escape))
			{
				Pause();
			}

			timeScore += Time.deltaTime;
			
			break;
			
		case GameState.Pause:

			if (Input.GetKeyDown(KeyCode.Escape))
				Resume();
			
			break;
			
		case GameState.GameOver:

            pause = waitActive;

			if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
			{
				anim.enabled = false;
				Application.LoadLevel (Application.loadedLevelName);
			}

			break;
			
		case GameState.Victory:
			
			if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
			{
				Application.LoadLevel (Application.loadedLevelName);
			}
			
			break;
			
		}

		if (state == lastState)
			return;

		ChangeScreen();

		lastState = state;
	}

	void ChangeScreen()
	{
		Vector3 pos = PauseScreen.transform.position;
		PauseScreen.transform.position = new Vector3(pos.x, pos.y, state == GameState.Pause ? -1 : 999999);
		pos = GameOverScreen.transform.position;
		GameOverScreen.transform.position = new Vector3(pos.x, pos.y, state == GameState.GameOver ? -1 : 999999);
	}

	void Victory()
	{
		state = GameState.Victory;
		pause = true;
	}

	void Pause()
	{
		state = GameState.Pause;
		pause = true;
	}
	
	void Resume()
	{
		state = GameState.Playing;
		pause = false;
	}

	void GameOver()
	{
        player.GetComponent<Rigidbody2D>().fixedAngle = false;
		state = GameState.GameOver;
		anim.enabled = true;
		anim.Play("Base Layer.testNeige");
        StartCoroutine(ded());
	}

	IEnumerator ded(){
		waitActive = false;
		yield return new WaitForSeconds (2.0f);
		waitActive = true;
	}

}
