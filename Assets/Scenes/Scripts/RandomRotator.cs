using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class RandomRotator : MonoBehaviour 
{
	[SerializeField]
	private float tumble;

	void Awake()
	{
		Assert.IsTrue(tumble == 2);
	}

	void Start () 
	{
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;
		// Random.insideUnitsohere: gives us random Vector3.
	}

}
