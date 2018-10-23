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

	public static int Score;

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

	private const float hazardXRange = 6f; //  hazard range (x) is from -6 to 6.
	private const float hazardInstantiatePosZ = 20f;

	private void Awake()
	{
		Assert.IsNotNull (hazard);
		Assert.IsNotNull (hazardBig);
		Assert.IsNotNull (scoreText);
		Assert.IsNotNull (restartText);
		Assert.IsNotNull (gameOverText);
	}

	private IEnumerator SpawnWaves()
	{
		while (!Gameover) 
		{
			for (int i = 0; i < numHazardPerWave; ++i) 
			{
				Vector3 hazardPos = new Vector3 (Random.Range (-hazardXRange, hazardXRange), 0f, hazardInstantiatePosZ);
				Instantiate (hazard, hazardPos, Quaternion.identity);
				yield return new WaitForSeconds (hazardTime);
			}

			Vector3 bigHazardPos = new Vector3 (Random.Range (-hazardXRange, hazardXRange), 0f, hazardInstantiatePosZ);
			Instantiate (hazardBig, bigHazardPos, Quaternion.identity);
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
		Score = 0;
		gameOverText.text = Strings.NullString;
		restartText.text = Strings.NullString;
	}

	public static void addScore()
	{
		Score += ScorePerHit;
	}

	private void Update () 
	{
		scoreText.text = $"Score: {Score}";
		if (restart && Input.GetKeyDown (KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}

