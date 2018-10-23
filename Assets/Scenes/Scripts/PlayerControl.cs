using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class PlayerControl : MonoBehaviour 
{
	[SerializeField]
	private GameObject shot;
	[SerializeField]
	private Transform shotSpot;
	[SerializeField]
	private float fireRate;
	[SerializeField]
	private GameObject playerEx;
	[SerializeField]
	private HealthBar playerHealthBar;

	public static int Health;
	public static bool Damaged;
	private float nextfire;
	private const float speed = 5;
	private const float tilt = 7;
	private Rigidbody rigidBody;
	private AudioSource audioSource;

	private void Awake()
	{
		Assert.IsNotNull (shotSpot);
		Assert.IsNotNull (shot);
		Assert.IsNotNull (playerEx);
		Assert.IsNotNull (playerHealthBar);

		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();

		Assert.IsNotNull (rigidBody);
		Assert.IsNotNull (audioSource);
	}


	private void Start () 
	{
		Damaged = false;
		Health = 5;
		nextfire = 0;
	}

	private void Damage()
	{
		--Health;

		if (Health == 0)
		{
			GameController.GameOver ();
			Instantiate (playerEx, transform.position, transform.rotation);
			Destroy (playerHealthBar.gameObject);
			Destroy (gameObject);
			return;
		}

		playerHealthBar.SetHealthValue (Health);
	}

	private void FixedUpdate()
	{
		if (!GameController.Gameover) 
		{
			float moveHorizontal = Input.GetAxis (Strings.HorizontalString);
			float moveVertical = Input.GetAxis (Strings.VerticalString);

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			movement *= speed;
			rigidBody.velocity = movement;
			rigidBody.position = 
				new Vector3 (
					Mathf.Clamp (rigidBody.position.x, Boundary.xMin, Boundary.xMax), 
					0f, 
					Mathf.Clamp (rigidBody.position.z, Boundary.zMin, Boundary.zMax));
			rigidBody.rotation = Quaternion.Euler (0f, 0f, rigidBody.velocity.x * -tilt);
		}
	}
		
	private void Update () 
	{
		if (Damaged) 
		{
			Damaged = false;
			Damage ();
		}

		if (Time.time > nextfire && Input.GetKeyDown(KeyCode.Space)) 
		{
			nextfire = Time.time + fireRate;
			Instantiate (shot, shotSpot.position, shotSpot.rotation);
			audioSource.Play ();
		}
	}
}
