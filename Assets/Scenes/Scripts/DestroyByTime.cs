using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

[System.Serializable]
public class DestroyByTime : MonoBehaviour 
{
	[SerializeField]
	private float timeBeforeDestroyed;
	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource> ();
		Assert.IsNotNull (audioSource);
		Assert.IsTrue (timeBeforeDestroyed > 0);
	}

	private void Start ()
	{
		audioSource.Play ();
		Destroy (gameObject, timeBeforeDestroyed);
	}
}
