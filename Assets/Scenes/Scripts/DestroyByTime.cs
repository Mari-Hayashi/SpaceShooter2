using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

[System.Serializable]
public class DestroyByTime : MonoBehaviour 
{
	[SerializeField]
	private float lifetime;

	void Awake(){
		Assert.IsTrue (lifetime > 0);
	}

	void Start () 
	{
		GetComponent<AudioSource> ().Play ();
		Destroy(gameObject, lifetime);
	}

}
