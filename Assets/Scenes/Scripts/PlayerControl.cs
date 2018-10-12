using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}
public class PlayerControl : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	public float tilt;
	public GameObject shot;
	public Transform shotspot;
	public float fireRate;
	private float nextfire;

	public GameObject player_ex;

	public static int health;
	public GameObject PlayerHealthBar;
	public Sprite sp_08;
	public Sprite sp_06;
	public Sprite sp_04;
	public Sprite sp_02;
	public Sprite sp_00;

	public static bool damaged;

	// Use this for initialization
	void Start () {
		damaged = false;
		health = 5;
	}
	public void Damage(){
		health--;

		Sprite sp = sp_00;
		switch (health){
		case 4:
			sp = sp_08;
			break;
		case 3:
			sp = sp_06;
			break;
		case 2:
			sp = sp_04;
			break;
		case 1:
			sp = sp_02;
			break;
		case 0:
			GameController.GameOver ();
			Instantiate (player_ex, this.transform.position, this.transform.rotation);
			Destroy (PlayerHealthBar);
			Destroy (this.gameObject);
			return;
		}
		PlayerHealthBar.GetComponent<SpriteRenderer> ().sprite = sp;
	}
	void FixedUpdate(){
		if (!GameController.gameover) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");


			Vector3 movement = new Vector3 (moveHorizontal * speed, 0.0f, moveVertical * speed);
			GetComponent<Rigidbody> ().velocity = movement;
			GetComponent<Rigidbody> ().position = new Vector3 (Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax), 
				0f, 
				Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax));
			GetComponent<Rigidbody> ().rotation = 
			Quaternion.Euler (0f, 0f, GetComponent<Rigidbody> ().velocity.x * -tilt);
		}
	}
	// Update is called once per frame
	void Update () {
		if (damaged) {
			Damage ();
			damaged = false;
		}
		if (Time.time > nextfire && Input.GetKeyDown(KeyCode.Space)) {
			nextfire = Time.time + fireRate;
			Instantiate (shot, shotspot.position, shotspot.rotation);
			GetComponent<AudioSource> ().Play ();
		}
	}
}
