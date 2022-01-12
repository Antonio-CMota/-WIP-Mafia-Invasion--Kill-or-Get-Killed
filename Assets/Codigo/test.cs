using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class test : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
   
    void Start()
    {
        Jogador.shopPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Jogador.shopPoints.ToString();
        
    }
}
