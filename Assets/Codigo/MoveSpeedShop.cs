using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveSpeedShop : MonoBehaviour
{

	public TextMeshProUGUI text;
	public TextMeshProUGUI priceText;
	private int price = 50;

	public void OnButtonPress()
	{


		if (Jogador.moveSpeedLvl < 5)
		{
			if(Jogador.shopPoints > price)
			{
				Jogador.shopPoints -= price;
				price += 75;
				Jogador.moveSpeedLvl++;
			}

			
		}
	}

	private void Update()
	{
		text.text = Jogador.moveSpeedLvl.ToString();
		priceText.text = ("Preco: " + price);
	}
}
