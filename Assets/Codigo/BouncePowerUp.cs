using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePowerUp : MonoBehaviour
{

	public TiroEliminar tiroEliminar;
	public GameObject bounce;
	public GameObject scriptHolder;
	public GameObject raio;
	public bool isCoroutineExecuting;
	public static int bounceCounter = 0;
	public Collider2D colliderCirculo;

	public GameObject bounceShop;


	private void Update()
	{

	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{

			
			Destroy(colliderCirculo);

			bounceCounter++;
			bounceShop.SetActive(true);

			Destroy(bounce);
		}
	}



	
}


