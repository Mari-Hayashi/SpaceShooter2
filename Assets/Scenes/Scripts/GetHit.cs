using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to Bolt
public class GetHit : MonoBehaviour 
{
	private int life = 2;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag.Equals(Tag.EnemyTag))
		{
			-- life;

			if (life == 0)Destroy(this.gameObject);

		}

	}

}