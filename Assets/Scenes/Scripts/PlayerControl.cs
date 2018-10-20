using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class Boundary
{
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}

public class PlayerControl : MonoBehaviour 
{
	[SerializeField]
	private float speed;
	[SerializeField]
	private Boundary boundary;
	[SerializeField]
	private float tilt;
	[SerializeField]
	private GameObject shot;
	[SerializeField]
	private Transform shotspot;
	[SerializeField]
	private float fireRate;

	[SerializeField]
	private GameObject player_ex;


	[SerializeField]
	private GameObject playerHealthBar;

	public static int Health;
	public static bool Damaged;
	private float nextfire;

	private Rigidbody getRigidbody;

	void Awake()
	{
		
		Assert.IsTrue (speed > 0);
		Assert.IsTrue (boundary.xMin < boundary.xMax);
		Assert.IsTrue (boundary.zMin < boundary.zMax);
		Assert.IsTrue (tilt > 0);
		Assert.IsNotNull (shotspot);
		Assert.IsNotNull (shot);
		Assert.IsNotNull (player_ex);
		Assert.IsNotNull (playerHealthBar);
			
	}


	void Start () 
	{
		Damaged = false;
		Health = 5;
		nextfire = 0;
		playerHealthBar.GetComponent<SetHealthBar>().SetHealthValue (10);
		getRigidbody = GetComponent<Rigidbody> ();
	}

	private void Damage()
	{
		--Health;

		if (Health == 0)
		{
			GameController.GameOver ();
			Instantiate (player_ex, transform.position, transform.rotation);
			Destroy (playerHealthBar);
			Destroy (gameObject);
			return;
		}

		playerHealthBar.GetComponent<SetHealthBar>().SetHealthValue (Health * 2);
	}

	void FixedUpdate()
	{
		if (!GameController.Gameover) 
		{
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");


			Vector3 movement = 
				new Vector3 (moveHorizontal, 0.0f, moveVertical);
			movement *= speed;
			getRigidbody.velocity = movement;
			getRigidbody.position = 
				new Vector3 
				(
					Mathf.Clamp (getRigidbody.position.x, boundary.xMin, boundary.xMax), 
					0f, 
					Mathf.Clamp (getRigidbody.position.z, boundary.zMin, boundary.zMax)
				);
			
			getRigidbody.rotation = 
				Quaternion.Euler (0f, 0f, getRigidbody.velocity.x * -tilt);
		}
	}


	void Update () 
	{
		if (Damaged) 
		{
			Damaged = false;
			Damage ();
		}

		if (Time.time > nextfire && Input.GetKeyDown(KeyCode.Space)) 
		{
			nextfire = Time.time + fireRate;
			Instantiate (shot, shotspot.position, shotspot.rotation);
			GetComponent<AudioSource> ().Play ();
		}

	}
}
