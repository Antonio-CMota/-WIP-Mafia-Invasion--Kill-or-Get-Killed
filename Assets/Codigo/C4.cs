using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4 : MonoBehaviour
{
	public GameObject ScriptHolder;
	public bool isCoroutineExecuting;
	public GameObject C4obj;
	public GameObject c4Shop;


    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Shooting.c4Count++;
			Destroy(C4obj);
			c4Shop.SetActive(true);
		}
	}
}
