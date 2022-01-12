using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
	
	public GameObject moneySprite;
	public GameObject scriptHolder;
	public bool isCoroutineExecuting;

	public Collider2D colliderCirculo;


	private void Update()
	{

	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Destroy(colliderCirculo);

			Jogador.shopPoints += Random.Range(10, 50);

			Destroy(moneySprite);
		}
	}
}
