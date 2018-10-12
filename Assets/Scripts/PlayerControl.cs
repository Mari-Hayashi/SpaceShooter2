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

	// Use this for initialization
	void Start () {
		
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");


		Vector3 movement = new Vector3(moveHorizontal * speed,0.0f,moveVertical * speed);
		GetComponent<Rigidbody> ().velocity = movement;
		GetComponent<Rigidbody> ().position = new Vector3 
			(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			 0f, 
			 Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
		GetComponent<Rigidbody> ().rotation = 
			Quaternion.Euler(0f,0f,GetComponent<Rigidbody>().velocity.x*-tilt);
	}
	// Update is called once per frame
	void Update () {
		
		if (Time.time > nextfire && Input.GetButton ("Fire1")) {
			nextfire = Time.time + fireRate;
			Instantiate (shot, shotspot.position, shotspot.rotation);
			GetComponent<AudioSource> ().Play ();
		}
	}
}
