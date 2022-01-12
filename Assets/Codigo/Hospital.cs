using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : MonoBehaviour
{
	public GameObject canvasHospital;

	public Collider2D hospitalColl;
	public Collider2D player;
	bool isHospital;


	private void Update()
	{
		if (GameObject.FindGameObjectsWithTag("Inimigo").Length == 0 && isHospital == true)
		{
			canvasHospital.SetActive(true);
		}
		else
		{
			canvasHospital.SetActive(false);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		isHospital = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		isHospital = false;
	}
}
