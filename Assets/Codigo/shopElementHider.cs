using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopElementHider : MonoBehaviour
{

    public GameObject shop;
    public static int powerCounter = 0;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

       if(Input.GetKeyDown(KeyCode.F10))
		{
            powerCounter = 0;
		}

        if (powerCounter > 0)
        {
            shop.SetActive(false);
        }
        else if (powerCounter == 0)
            shop.SetActive(true);
    }
}
