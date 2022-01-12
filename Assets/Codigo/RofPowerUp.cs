using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RofPowerUp : MonoBehaviour
{

    public Shooting shooting;
	public GameObject circulo;
	public GameObject scriptHolder;
	public bool isCoroutineExecuting;
	public static int rofCounter;
	
	public Collider2D colliderCirculo;

	public GameObject rofShop;

	private void Start()
	{
		rofCounter = 0;
	}

	private void Update()
	{
		
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Destroy(colliderCirculo);
			rofCounter++;
			rofShop.SetActive(true);
			Destroy(circulo);
			Debug.Log("ROFCOUNTER" + rofCounter);

		}
	}



	

	


}
