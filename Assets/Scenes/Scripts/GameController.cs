using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public GameObject hazard_big;
	public Vector3 Spownvalues;
	public int hazardct;
	public float hazardtime;
	public float wavetime;
	public GameObject scoretext;
	private static int score;

	public GameObject restarttext;
	public GameObject gameovertext;

	public static bool gameover;
	private bool restart;

	IEnumerator SpawnWaves(){
		
		while (!gameover) {
			
			for (int i = 0; i < hazardct; ++i) {
				Vector3 Sppos = new Vector3 (Random.Range (-6f, 6f), 0f, 20f);
				Instantiate (hazard, Sppos, Quaternion.identity);
				yield return new WaitForSeconds (hazardtime);
			}
			Vector3 Sppos2 = new Vector3 (Random.Range (-6f, 6f), 0f, 20f);
			Instantiate (hazard_big, Sppos2, Quaternion.identity);
			yield return new WaitForSeconds (wavetime);
			if (gameover) {
				restarttext.GetComponent<TextMesh> ().text = "Press \"R\" for restart.";
				gameovertext.GetComponent<TextMesh> ().text = "Game Over";
				restart = true;
				break;
			}
		}
	}
	public static void GameOver(){
		gameover = true;
	}
	// Use this for initialization
	void Start () {
		gameover = false;
		restart = false;
		StartCoroutine (SpawnWaves ());
		score = 0;
		gameovertext.GetComponent<TextMesh> ().text = "";
		restarttext.GetComponent<TextMesh> ().text = "";
	}
	public static void addscore(int n_score){
		score += n_score;
	}
	// Update is called once per frame
	void Update () {
		scoretext.GetComponent<TextMesh> ().text = "Score: " + score;
		if (restart){
			if (Input.GetKeyDown (KeyCode.R)) {
				//Application.LoadLevel (Application.loadedLevel);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);

			}
		}
			
	}
}
