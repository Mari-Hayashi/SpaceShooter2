using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class Mover : MonoBehaviour 
{
	
	[SerializeField]
	private float speed;

	void Start () 
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}
}
