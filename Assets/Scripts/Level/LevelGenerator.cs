using UnityEngine;
using System.Collections;
using System.Linq;

public class LevelGenerator : MonoBehaviour
{
	public enum CaseType
	{
		Solid,
		Hole,
		Wall
	}
	
	public GameObject prefabGround;
	public GameObject prefabWall;
	
	public int seed = 0;
	public bool fixSeed = false;
	public int difficulty = 1;
	
	private CaseType[][] level;
	
	private const int nbLines = 3;
	private const int nbColumns = 14;
	
	private const int marginHole = 1;
	private const int marginWall = 4;
	
	private const float probalityFixWall = 0.2f;
	private const float probalityMultiWall = 0.1f;
	private const float reduceProbalityHoleInit = 0.1f;
	private const float reduceProbalityHoleWhenWall = 0.6f;
	private const float reduceProbalityHoleMulti = 0.02f;

	public Vector2 sizeCase = new Vector2(1.2f, 5);
	
	// Use this for initialization
	void Start()
	{
		ProceduralProcess();
		
		for(int i  = 0; i < nbLines; i++)
		{
			for(int j = 0; j < nbColumns; j++)
			{
				if(level[i][j] == CaseType.Solid)
				{
					float x = transform.position.x + ((float)j - nbColumns / 2 + 0.5f) * sizeCase.x;
					float y = transform.position.y + ((float)i - nbLines / 2) * sizeCase.y;

					GameObject clone = (GameObject)Instantiate(prefabGround, new Vector3(x, y, 0), Quaternion.identity);
					clone.transform.parent = transform;
				}
				if(level[i][j] == CaseType.Wall)
				{
					float x = transform.position.x + ((float)j - nbColumns / 2 + 0.5f) * sizeCase.x;
					float y = transform.position.y + ((float)i - nbLines / 2) * sizeCase.y;

					GameObject clone = (GameObject)Instantiate(prefabGround, new Vector3(x, y, 0), Quaternion.identity);
					clone.transform.parent = transform;
					
					y += sizeCase.y / 2;

					clone = (GameObject)Instantiate(prefabWall, new Vector3(x, y, 0), Quaternion.identity);
					clone.transform.parent = transform;
				}
			}
		}
	}
	
	void ProceduralProcess ()
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
				
				do { column = Random.Range(marginHole, caseWall - 1);
				} while (!ConditionHole(i, column));
				level[i][column] = CaseType.Hole;
				
				do { column = Random.Range(caseWall + 1, nbColumns - 1 - marginHole);
				} while (!ConditionHole(i, column));
				level[i][column] = CaseType.Hole;
				
				reduceProbality = reduceProbalityHoleWhenWall;
			}
			else
			{
				do { column = Random.Range(marginHole, nbColumns - 1 - marginHole);
				} while (!ConditionHole(i, column));
				level[i][column] = CaseType.Hole;
			}
			
			while (RandomByDifficulty(1f - reduceProbality, reduceProbalityHoleMulti))
			{
				do { column = Random.Range(marginHole, nbColumns - 1 - marginHole);
				} while (!ConditionHole(i, column));
				level[i][column] = CaseType.Hole;
				
				reduceProbality = reduceProbality * 2 + 0.1f;
			}
		}
	}
	
	bool ConditionHole(int i, int j)
	{
		return level[i][j] == CaseType.Solid
			&& (i <= 0 || level[i-1][j] == CaseType.Solid)
				&& (i >= nbLines - 1 || level[i+1][j] == CaseType.Solid);
	}
	
	bool RandomByDifficulty(float baseValue, float difficultyMultiplier)
	{
		return Random.value < baseValue + difficultyMultiplier * difficulty;
	}
}
