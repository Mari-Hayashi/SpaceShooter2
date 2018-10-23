using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

[System.Serializable]
public class GameController : MonoBehaviour 
{
	[SerializeField]
	private GameObject hazard;
	[SerializeField]
	private GameObject hazardBig;
	[SerializeField]
	public TextMesh scoreText;
	[SerializeField]
	private static int score;

	[SerializeField]
	private TextMesh restartText;
	[SerializeField]
	private TextMesh gameOverText;

	public static bool Gameover;
	private bool restart;
	public const int ScorePerHit = 10;

	private const int numHazardPerWave = 5;
	private const float hazardTime = 0.25f;
	private const float waveTime = 3;

	void Awake()
	{
		Assert.IsNotNull (hazard);
		Assert.IsNotNull (hazardBig);
		Assert.IsNotNull (scoreText);
		Assert.IsNotNull (restartText);
		Assert.IsNotNull (gameOverText);
	}

	IEnumerator SpawnWaves()
	{
		while (!Gameover) 
		{
			for (int i = 0; i < numHazardPerWave; ++i) 
			{
				Vector3 Sppos = new Vector3 (Random.Range (-6f, 6f), 0f, 20f);
				Instantiate (hazard, Sppos, Quaternion.identity);
				yield return new WaitForSeconds (hazardTime);
			}

			Vector3 Sppos2 = new Vector3 (Random.Range (-6f, 6f), 0f, 20f);
			Instantiate (hazardBig, Sppos2, Quaternion.identity);
			yield return new WaitForSeconds (waveTime);

			if (Gameover) 
			{
				restartText.text = Strings.RestartString;
				gameOverText.text = Strings.GameOverString;
				restart = true;
				break;
			}
		}
	}

	public static void GameOver()
	{
		Gameover = true;
	}

	private void Start () 
	{
		Gameover = false;
		restart = false;
		StartCoroutine (SpawnWaves ());
		score = 0;
		gameOverText.text = Strings.NullString;
		restartText.text = Strings.NullString;
	}

	public static void addScore()
	{
		score += ScorePerHit;
	}

	private void Update () 
	{
		scoreText.text = Strings.ScoreString + score;
		//When I did "scoreText.text = $"Score: {score}",score;", it said:
		//'interpolated strings' cannot be used because it is not part of the C# 4.0 language specification.
		if (restart && Input.GetKeyDown (KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}

