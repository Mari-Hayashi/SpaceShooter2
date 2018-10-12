using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour {
	private int life;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Enemy"){
			life --;

			if (life == 0){
				Destroy(this.gameObject);
			}
		}
	}
	// Use this for initialization
	void Start () {
		life = 2;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
