using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroEliminar : MonoBehaviour
{

	private bool isCoroutineExecuting = false;
	public int currentBounce;
	public bool isBounce = false;
	public float waitTime = 0f;


	private void Update()
	{
		
	}

	private void OnCollisionEnter2D(Collision2D colisao)
    {
		currentBounce++;



		if (isBounce == true)
		{
			waitTime = 1f;

			if (currentBounce == 1)
			{
				GetComponent<BoxCollider2D>().isTrigger = true;
				StartCoroutine(BulletDecay());
			}
		}
		else
			DestruirBalaImediata();

	}


	IEnumerator BulletDecay()
	{
		if (isCoroutineExecuting)
			yield break;

		isCoroutineExecuting = true;

		yield return new WaitForSeconds(waitTime);

		Destroy(gameObject);
		
	}

	private void DestruirBalaImediata()
	{
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		Destroy(gameObject);
	}
}
