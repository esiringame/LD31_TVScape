using UnityEngine;
using System.Collections;

public class SpawnColored : MonoBehaviour
{
	public Vector2 spawnPoint;
	public int difficulty = 1;
	public GameObject prefab;
	public GameObject player;

	public Sprite spriteRed;
	public Sprite spriteGreen;
	public Sprite spriteBlue;
	public Sprite spriteYellow;
	public Sprite spriteMagenta;
	public Sprite spriteCyan;

	public GameObject componentsRGB;

	private float delayElapsed;
	private const float emissionDelayInit = 5;

	private float emissionDelay
	{
		get { return emissionDelayInit - difficulty * 0.4f; }
	}

	// Use this for initialization
	void Start ()
	{
		delayElapsed = 0;
		GenerateColored();
	}
	
	// Update is called once per frame
	void Update ()
	{
		delayElapsed += Time.deltaTime;

		if (delayElapsed > emissionDelay)
		{
			GenerateColored();
			delayElapsed -= emissionDelay;
		}
	}

	void GenerateColored()
	{
		Sprite spriteToRender;

		ColoredBehaviour.ColorType type;
		if (difficulty <= 5)
			type = (ColoredBehaviour.ColorType)Random.Range(0, 3);
		else
			type = (ColoredBehaviour.ColorType)Random.Range(0, 6);

		switch (type)
		{
			case ColoredBehaviour.ColorType.Red: spriteToRender = spriteRed; break;
			case ColoredBehaviour.ColorType.Green: spriteToRender = spriteGreen; break;
			case ColoredBehaviour.ColorType.Blue: spriteToRender = spriteBlue; break;
			case ColoredBehaviour.ColorType.Yellow: spriteToRender = spriteYellow; break;
			case ColoredBehaviour.ColorType.Magenta: spriteToRender = spriteMagenta; break;
			case ColoredBehaviour.ColorType.Cyan: spriteToRender = spriteCyan; break;
			default: spriteToRender = spriteRed; break;
		}
		//prefab.renderer = coloredRenderer;

		GameObject colored = Instantiate(prefab, new Vector3 (spawnPoint.x, spawnPoint.y, 0), Quaternion.identity) as GameObject;
		colored.GetComponent<ColoredBehaviour> ().componentsRGB = componentsRGB;
		colored.GetComponent<ColoredBehaviour> ().player = player;
		colored.GetComponent<SpriteRenderer>().sprite = spriteToRender;
	}
}
