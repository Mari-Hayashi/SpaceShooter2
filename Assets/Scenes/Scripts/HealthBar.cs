using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

//attach to Healthbar
public class HealthBar : MonoBehaviour 
{
	private TextMesh textMesh;

	private void Awake()
	{
		textMesh = GetComponent<TextMesh> ();
		Assert.IsNotNull (textMesh);
	}

	public void SetHealthValue(int HealthValue)
	{
		textMesh.text = HealthValue.ToString();
	}

}
