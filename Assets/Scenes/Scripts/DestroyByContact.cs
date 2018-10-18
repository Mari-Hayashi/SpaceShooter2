using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;

	public int astroid_health;

	public GameObject healthbar;
	public Sprite sp_00;
	public Sprite sp_05;

	void hit(){

		astroid_health--;

		if (astroid_health == 1) {
			healthbar.GetComponent<SpriteRenderer> ().sprite = sp_05;

		} else {
			Destroy (healthbar);
			Destroy (this.gameObject);
			GameController.addscore (10);
			Instantiate (explosion, this.transform.position, this.transform.rotation);
		}
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Bolt") {
			hit ();

		}
		else if (col.gameObject.tag == "Player"){
			PlayerControl.damaged = true;
			hit ();
			}
		}
}
