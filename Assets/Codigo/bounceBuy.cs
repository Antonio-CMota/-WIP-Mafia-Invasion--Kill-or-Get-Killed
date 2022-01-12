using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bounceBuy : MonoBehaviour
{
	public TextMeshProUGUI priceText;
	private int price = 75;

	public void OnButtonPress()
	{
		if (Jogador.shopPoints > price)
		{
			shopElementHider.powerCounter++;
			BouncePowerUp.bounceCounter++;
		}
	}

	private void Update()
	{
		priceText.text = ("Preco: " + price);
	}
}
