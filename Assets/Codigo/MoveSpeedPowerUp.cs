using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedPowerUp : MonoBehaviour
{
	public Jogador jogador;
	public GameObject botas;
	public GameObject scriptHolder;
	public bool isCoroutineExecuting;
	public static int moveSpeedCounter;

	public Collider2D colliderCirculo;

	public GameObject moveSpeedShop;

	private void Start()
	{
		moveSpeedCounter = 0;
	}

	private void Update()
	{

	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Destroy(colliderCirculo);

			moveSpeedCounter++;
			moveSpeedShop.SetActive(true);
			Destroy(botas);
		}
	}



}
