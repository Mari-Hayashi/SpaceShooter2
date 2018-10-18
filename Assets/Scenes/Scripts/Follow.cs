using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
	public GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (obj != null) {
			Transform trans = obj.transform;
			this.transform.position = trans.position - new Vector3 (0f, 0f, 1.5f);
		} else {
			Destroy (this);
		}
	}
}
