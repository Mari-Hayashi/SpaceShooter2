using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;


[System.Serializable]
public class Follow : MonoBehaviour 
{
	[SerializeField]
	private Transform objToFollow;

	void Awake()
	{
		Assert.IsNotNull (objToFollow);
	}

	void Update() 
	{
		if (objToFollow != null) 
		{
			transform.position = objToFollow.position - new Vector3 (0f, 0f, 1.5f);
		} 
		else 
		{
			Destroy(this);
		}
	}

}
