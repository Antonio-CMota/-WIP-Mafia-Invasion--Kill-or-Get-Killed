using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C4Buy : MonoBehaviour
{
	// Start is called before the first frame update

	public TextMeshProUGUI priceText;
	private int price = 100;

	public void OnButtonPress()
	{
		if (Jogador.shopPoints > price)
		{
			Shooting.c4Count++;
			Debug.Log(Shooting.c4Count + " beans");
			shopElementHider.powerCounter++;
		}
	}

	private void Update()
	{
		priceText.text = ("Preco: " + price);
	}
}
