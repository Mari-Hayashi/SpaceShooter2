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
	private HealthBar healthbar;
	[SerializeField]
	private int astroidHealth;

	private void Awake()
	{
		Assert.IsNotNull (explosion);
		Assert.IsNotNull (healthbar);
		Assert.IsTrue (astroidHealth > 0);
	}

	private void Start()
	{
		healthbar.SetHealthValue(astroidHealth);
	}

	private void Hit()
	{
		--astroidHealth;

		if (astroidHealth <= 0) 
		{
			Destroy (healthbar.gameObject);
			Destroy (gameObject);
			GameController.addScore ();
			Instantiate (explosion, this.transform.position, this.transform.rotation);
		} 
		else 
		{
			healthbar.SetHealthValue (astroidHealth);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag.Equals(Tag.Tags.Bolt))
		{
			Hit ();
		}
		else if (col.gameObject.tag.Equals(Tag.Tags.Player))
		{
			col.gameObject.GetComponent<PlayerControl> ().Damage ();
			Hit ();
		}
	}
}
