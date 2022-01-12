using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthShop : MonoBehaviour
{
	public TextMeshProUGUI text;
	public TextMeshProUGUI priceText;
	public int price = 50;
	//public static bool increaseMaxHealth;

	public void OnButtonPress()
	{

		if (Jogador.healthLvl < 5)
		{
			if (Jogador.shopPoints > price)
			{
				Jogador.shopPoints -= price;
				price += 75;
				Jogador.healthLvl++;
				//increaseMaxHealth = true;
				
			}


		}
	}

	private void Update()
	{
		priceText.text = ("Preco: " + price);
		Debug.Log(Shooting.rofLvl);
		text.text = Jogador.healthLvl.ToString();
	}
}
