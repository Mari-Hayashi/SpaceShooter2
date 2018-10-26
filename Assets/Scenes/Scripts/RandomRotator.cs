using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class RandomRotator : MonoBehaviour 
{
	private const float tumble = 2f;
	private Rigidbody rigidBody;

	private void Awake(){
		rigidBody = GetComponent<Rigidbody> ();
		Assert.IsNotNull (rigidBody);
	}

	private void Start () 
	{
		rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
