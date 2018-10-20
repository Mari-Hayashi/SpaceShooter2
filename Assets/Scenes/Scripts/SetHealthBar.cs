using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to Healthbar
public class SetHealthBar : MonoBehaviour 
{
	[SerializeField]
	private Sprite HealthBar100;
	[SerializeField]
	private Sprite HealthBar20;
	[SerializeField]
	private Sprite HealthBar40;
	[SerializeField]
	private Sprite HealthBar60;
	[SerializeField]
	private Sprite HealthBar80;
	[SerializeField]
	private Sprite HealthBar50;

	public void SetHealthValue(int a)
	{
		
		Sprite sp = null;

		switch (a) 
		{
			case 2:
				sp = HealthBar20;
				break;
			case 4:
				sp = HealthBar40;
				break;
			case 6:
				sp = HealthBar60;
				break;
			case 8:
				sp = HealthBar80;
				break;
			case 10:
				sp = HealthBar100;
				break;
			default:
				sp = HealthBar50;
				break;
		}

		GetComponent<SpriteRenderer> ().sprite = sp;

	}

	void Start () 
	{
		GetComponent<SpriteRenderer> ().sprite = HealthBar100;
	}

}
