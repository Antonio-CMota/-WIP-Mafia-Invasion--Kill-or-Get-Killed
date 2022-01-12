using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Healer : MonoBehaviour
{
    public HealthBar healthBar;
    public TextMeshProUGUI priceText;
    private int price = 100;

    public void OnButtonPress()
    {
        if (Jogador.shopPoints > price)
        {
            if (Jogador.vidaAtual < Jogador.MaxVida)
            {
                Jogador.shopPoints -= price;
                if (Jogador.vidaAtual + 50 < Jogador.MaxVida)
                {
                    Jogador.vidaAtual += 50;
                    healthBar.SetHealth(Jogador.vidaAtual);
                }
                else if (Jogador.vidaAtual + 50 > Jogador.MaxVida)
                {
                    Jogador.vidaAtual += Jogador.MaxVida - Jogador.vidaAtual;
                    healthBar.SetHealth(Jogador.vidaAtual);
                }
            }
        }
    }

    private void Update()
    {
        priceText.text = ("Preco: " + price);
    }
}
