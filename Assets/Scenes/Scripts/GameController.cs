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
	private GameObject hazard_big;
	[SerializeField]
	private int hazardct;
	[SerializeField]
	private float hazardtime;
	[SerializeField]
	private float wavetime;
	[SerializeField]
	public TextMesh scoretext;
	[SerializeField]
	private static int score;

	[SerializeField]
	private TextMesh restarttext;
	[SerializeField]
	private TextMesh gameovertext;

	public static bool Gameover;
	private bool restart;

	void Awake()
	{
		Assert.IsNotNull (hazard);
		Assert.IsNotNull (hazard_big);
		Assert.IsNotNull (scoretext);
		Assert.IsNotNull (restarttext);
		Assert.IsNotNull (gameovertext);
		Assert.IsTrue (hazardtime > 0);
		Assert.IsTrue (wavetime > 0);

	}

	IEnumerator SpawnWaves()
	{
		
		while (!Gameover) 
		{
			
			for (int i = 0; i < hazardct; ++i) 
			{
				Vector3 Sppos = new Vector3 (Random.Range (-6f, 6f), 0f, 20f);
				Instantiate (hazard, Sppos, Quaternion.identity);
				yield return new WaitForSeconds (hazardtime);
			}

			Vector3 Sppos2 = new Vector3 (Random.Range (-6f, 6f), 0f, 20f);
			Instantiate (hazard_big, Sppos2, Quaternion.identity);
			yield return new WaitForSeconds (wavetime);

			if (Gameover) 
			{
				restarttext.text = "Press \"R\" for restart.";
				gameovertext.text = "Game Over";
				restart = true;
				break;
			}
		}
	}

	public static void GameOver()
	{
		Gameover = true;
	}

	void Start () 
	{
		Gameover = false;
		restart = false;
		StartCoroutine (SpawnWaves ());
		score = 0;
		gameovertext.text = "";
		restarttext.text = "";
	}

	public static void addscore(int n_score)
	{
		score += n_score;
	}

	void Update () 
	{
		scoretext.text = "Score: " + score;
		if (restart && Input.GetKeyDown (KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		}
	}
			
}

