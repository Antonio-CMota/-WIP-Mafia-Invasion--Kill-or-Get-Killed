using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timescale : MonoBehaviour
{

    public int Tempo;


    void Start()
    {
        Time.timeScale = Tempo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
