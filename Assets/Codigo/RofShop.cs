using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RofShop : MonoBehaviour
{
	public TextMeshProUGUI text;
	public TextMeshProUGUI priceText;
	public int price = 50;

	public void OnButtonPress()
	{
		
		if (Shooting.rofLvl < 5)
		{
			if(Jogador.shopPoints > price)
			{
				Jogador.shopPoints -= price;
				price += 75;
				Shooting.rofLvl++;
			}

			
		}
	}

	private void Update()
	{
		priceText.text = ("Preco: " + price);
		Debug.Log(Shooting.rofLvl);
		text.text = Shooting.rofLvl.ToString();
	}
}
