using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class Mover : MonoBehaviour 
{
	[SerializeField]
	private float speed;
	private Rigidbody rigidBody;

	private void Awake()
	{
		rigidBody = GetComponent<Rigidbody> ();
		Assert.IsNotNull (rigidBody);
	}

	private void Start () 
	{
		rigidBody.velocity = transform.forward * speed;
	}
}
