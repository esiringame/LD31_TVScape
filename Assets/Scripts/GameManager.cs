using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public enum GameState
	{
		Menu,
		Playing,
		Pause,
		GameOver
	}
	
	public GameState state;
	private GameState lastState;

	public GameObject PauseScreen;
	public GameObject GameOverScreen;
	public GameObject player;
	
	private float timeScore;

	private bool pause
	{
		set { Time.timeScale = value ? 0.0f : 1.0f; }
	}

	// Use this for initialization
	void Start ()
	{
		state = GameState.Playing;
		timeScore = 0;

		pause = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (state)
		{
			
		case GameState.Playing:

			if (player.GetComponent<PlayerMotor>().life <= 0)
			{
				GameOver();
				break;
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Pause();
				break;
			}

			timeScore += Time.deltaTime;
			
			break;
			
		case GameState.Pause:
			
			break;
			
		case GameState.GameOver:
			
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
		PauseScreen.transform.position = new Vector3(pos.x, pos.y, state == GameState.Pause ? 1 : 999999);
		pos = GameOverScreen.transform.position;
		GameOverScreen.transform.position = new Vector3(pos.x, pos.y, state == GameState.GameOver ? 1 : 999999);
	}

	void Pause()
	{
		state = GameState.Pause;
		pause = true;
	}

	void GameOver()
	{
		state = GameState.GameOver;
		pause = true;
	}
}
