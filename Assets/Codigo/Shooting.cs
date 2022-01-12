using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{


	public Transform balaponto;
	public GameObject balaPrefab;
	public Collider2D colliderbala;
	public Collider2D colliderplayer;


	public GameObject c4prefab;
	public float balaForce = 20f;
	public float baseRof;
	public float rof;
	public float lastFired;
	public static int c4Count;
	public GameObject buttonc4;
	public GameObject buttonRof;
	public bool isRof;

	public bool isFiring;

	public ShootingJoystick shootingJoystick;

	public AudioSource tiro;

	private int bulletCount;

	public static int rofLvl = 1;

	public GameObject circulo;
	public GameObject scriptHolder;
	public bool isCoroutineExecuting;

	public GameObject muzzle;


    // Update is called once per frame
    void Update()
	{

		if (rofLvl == 1)
			baseRof = 7.5f;
		if (rofLvl == 2)
			baseRof = 8f;
		if (rofLvl == 3)
			baseRof = 8.5f;
		if (rofLvl == 4)
			baseRof = 9.35f;
		if (rofLvl == 5)
			baseRof = 10;

		if(!isRof)
		{
			rof = baseRof;
		}
		

		//if(Input.GetKey(KeyCode.Mouse0))
		if (shootingJoystick.joystickVec.y != 0)
		{
			Bala();
		}
		if (c4Count > 0)
        {
			buttonc4.SetActive(true);
        }
        else
        {
			buttonc4.SetActive(false);
		}
		if (RofPowerUp.rofCounter > 0)
		{
			buttonRof.SetActive(true);
		}
		else
		{
			buttonRof.SetActive(false);
		}

	}

	public void Bala()
	{

		if (Time.time - lastFired > 1 / rof)
		{
			lastFired = Time.time;
			GameObject bala = Instantiate(balaPrefab, balaponto.position, balaponto.rotation);
			muzzle.SetActive(true);
			Invoke("MuzzleTurnOff", 0.1f);
			bulletCount++;
			tiro.Play();
			Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
			rb.AddForce(balaponto.up * balaForce, ForceMode2D.Impulse);
		}
	}

	public void pointerDown()
	{
		isFiring = true;
	}

	public void pointerUp()
	{
		isFiring = false;
	}

	public void dropC4()
    {
		if (c4Count > 0)
		{
			GameObject c4 = Instantiate(c4prefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
			c4Count--;
		}
	}

	public void Rof()
	{
		if (RofPowerUp.rofCounter >= 1)
		{
			isRof = true;
			if (isRof)
			{
				rof = baseRof + Random.Range(1, 5);
			}
			RofPowerUp.rofCounter--;			
		
			StartCoroutine(ExecuteAfterTime());

		}

	}

	public void MuzzleTurnOff()
	{
		muzzle.SetActive(false);
	}

	IEnumerator ExecuteAfterTime()
	{

		if (isCoroutineExecuting)
			yield break;

		isCoroutineExecuting = true;

		yield return new WaitForSeconds(5);

		isRof = false;		

		isCoroutineExecuting = false;

		Destroy(scriptHolder);

	}


}
