using UnityEngine;
using System.Collections;

public class SpawnColored : MonoBehaviour
{
	public Vector2 spawnPoint;
	public int difficulty = 1;

	public GameObject prefabRed;
	public GameObject prefabGreen;
	public GameObject prefabBlue;
	public GameObject prefabYellow;
	public GameObject prefabMagenta;
	public GameObject prefabCyan;

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
		ColoredBehaviour.ColorType type;
		if (difficulty <= 5)
			type = (ColoredBehaviour.ColorType)Random.Range(0, 3);
		else
			type = (ColoredBehaviour.ColorType)Random.Range(0, 6);

		GameObject prefab;

		switch (type)
		{
		case ColoredBehaviour.ColorType.Red: prefab = prefabRed; break;
		case ColoredBehaviour.ColorType.Green: prefab = prefabGreen; break;
		case ColoredBehaviour.ColorType.Blue: prefab = prefabBlue; break;
		case ColoredBehaviour.ColorType.Yellow: prefab = prefabYellow; break;
		case ColoredBehaviour.ColorType.Magenta: prefab = prefabMagenta; break;
		case ColoredBehaviour.ColorType.Cyan: prefab = prefabCyan; break;
		default: prefab = prefabRed; break;
		}

		GameObject colored = Instantiate(prefab, new Vector3 (spawnPoint.x, spawnPoint.y, 0), Quaternion.identity) as GameObject;
		colored.GetComponent<ColoredBehaviour>().componentsRGB = componentsRGB;
	}
}
