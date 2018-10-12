using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject reference;
	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Bolt") {
			Destroy (col.gameObject);
			Destroy (gameObject);
			GameController.addscore (10);
			Instantiate (explosion, this.transform.position, this.transform.rotation);
		} else if (col.gameObject.tag == "Player"){
			GameController.GameOver ();
			Instantiate (reference, this.transform.position, this.transform.rotation);
			Destroy (col.gameObject);
			Destroy (gameObject);

		}
	
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
