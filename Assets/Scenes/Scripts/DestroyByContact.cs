using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class DestroyByContact : MonoBehaviour 
{

	[SerializeField]
	private GameObject explosion;
	[SerializeField]
	private GameObject healthbar;
	[SerializeField]
	private int astroid_health;

	void Awake()
	{
		Assert.IsNotNull (explosion);
		Assert.IsNotNull (healthbar);
		Assert.IsTrue (astroid_health > 0);
	}

	private void Hit()
	{

		astroid_health--;

		if (astroid_health == 0) 
		{
			Destroy (healthbar);
			Destroy (gameObject);
			GameController.addscore (10);
			Instantiate (explosion, this.transform.position, this.transform.rotation);
		} 
		else 
		{
			healthbar.GetComponent<SetHealthBar> ().SetHealthValue (5);
		}

	}

	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag.Equals(Tag.BoltTag))
		{
			Hit ();

		}
		else if (col.gameObject.tag.Equals(Tag.PlayerTag))
		{
			PlayerControl.Damaged = true;
			Hit ();
		}
	}

}
