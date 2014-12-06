using UnityEngine;
using System.Collections;
using System.Linq;

public class ProceduralMotor : MonoBehaviour {

	public enum CaseType
	{
		Solid,
		Hole,
		Wall
	}
	
	public int seed = 0;
	public bool fixSeed = false;
	public int difficulty = 1;

	public int nbLines = 3;
	public int nbColumns = 20;
	
	private const int marginHole = 1;
	private const int marginWall = 4;

	private CaseType[][] level;

	public float probalityFixWall = 0.2f;
	public float probalityMultiWall = 0.1f;
	public float reduceProbalityHoleInit = 0.1f;
	public float reduceProbalityHoleWhenWall = 0.6f;
	public float reduceProbalityHoleMulti = 0.02f;

	// Use this for initialization
	void Start ()
	{
		if (fixSeed)
			Random.seed = seed;

		level = new CaseType[nbLines][];
		for (int i = 0; i < nbLines; i++)
			level[i] = new CaseType[nbColumns];

		PlaceWalls();
		PlaceHoles();
	}

	void PlaceWalls()
	{
		for (int i = 0; i < nbLines; i++)
		{
			if (i > 0 && level[i-1].Contains(CaseType.Wall))
				continue;

			if (!RandomByDifficulty(probalityFixWall, probalityMultiWall))
				continue;

			int column = Random.Range(marginWall, nbColumns - 1 - marginWall);
			level[i][column] = CaseType.Wall;
		}
	}

	void PlaceHoles()
	{
		int column;
		for (int i = 0; i < nbLines; i++)
		{
			float reduceProbality = reduceProbalityHoleInit;
			if (level[i].Contains(CaseType.Wall))
			{
				int caseWall = 0;
				for(int j = 0; j < nbColumns; j++)
				{
					if (level[i][j] == CaseType.Wall)
					{
						caseWall = j;
						break;
					}
				}
				
				column = Random.Range(marginHole, caseWall - 1);
				level[i][column] = CaseType.Hole;
				column = Random.Range(caseWall + 1, nbColumns - 1 - marginHole);
				level[i][column] = CaseType.Hole;

				reduceProbality = reduceProbalityHoleWhenWall;
			}
			else
			{
				column = Random.Range(marginHole, nbColumns - 1 - marginHole);
				level[i][column] = CaseType.Hole;
			}

			while (RandomByDifficulty(1f - reduceProbality, reduceProbalityHoleMulti))
			{
				column = Random.Range(marginHole, nbColumns - 1 - marginHole);
				level[i][column] = CaseType.Hole;

				reduceProbality = reduceProbality * 2 + 0.1f;
			}
		}
	}

	bool RandomByDifficulty(float baseValue, float difficultyMultiplier)
	{
		return Random.value < baseValue + difficultyMultiplier * difficulty;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
