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
	
	private float timeScore;

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
		state = GameState.Playing;
		timeScore = 0;
		
		InitGame();
		pause = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (state)
		{
			
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

	void InitGame()
	{
		state = GameState.Playing;
		pause = false;

		player.GetComponent<PlayerMotor>().life = 3;
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
		state = GameState.GameOver;
		anim.enabled = true;
		anim.Play("Base Layer.testNeige");
		pause = true;
	}
}
