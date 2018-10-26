using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

[System.Serializable]
public class Follow : MonoBehaviour 
{
	[SerializeField]
	private Transform objToFollow;
	[SerializeField]
	private float zOffset;

	private Vector3 offset;

	private void Awake()
	{
		Assert.IsNotNull (objToFollow);
		offset = new Vector3 (0f, 0f, zOffset);
	}

	private void Update() 
	{
		if (objToFollow != null) 
		{
			transform.position = objToFollow.position + offset;
		} 
		else 
		{
			Destroy(this);
		}
	}
}
