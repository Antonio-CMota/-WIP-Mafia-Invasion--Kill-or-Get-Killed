using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public GameObject canvasShop;
	public GameObject vida;
	

	public Collider2D carrinha;
	public Collider2D player;

	bool isShop;


	private void Update()
	{
		if (GameObject.FindGameObjectsWithTag("Inimigo").Length == 0 && isShop == true)
		{
			canvasShop.SetActive(true);
			vida.SetActive(false);
			
		}
		else
		{
			canvasShop.SetActive(false);
			vida.SetActive(true);
			
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.name == "Player")
		{
			isShop = true;
		}
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.gameObject.name == "Player")
		{
			isShop = false;
		}
	}

	

}
