using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public Transform player;
	public float moveSpeed;
	private Rigidbody2D rb;
	private Vector2 movement;
	private Vector3 movimento;
	public Vector2 projDirection;
	public Transform balaponto;

	public Rigidbody2D rb2;



	public Jogador jogadorScript;

	public Animator animator;

	public int MaxVida = 1000;
	public int vidaAtual;
	public HealthBar healthBar;

	public bool hit = true;
	public int contarMortes;

	public GameObject Bala;
	public float rof = 10;
	public float lastFired;
	float nextFire;
	public int DanoBala;

	public GameObject money;


	



	void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();

		vidaAtual = MaxVida;
		healthBar.SetMaxHealth(MaxVida);
		//jogadorScript.shopPoints = 0;

	}

	void Update()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;

		

		balaponto.transform.position = gameObject.transform.position;

		if (vidaAtual <= 0)
		{
			InimigoSpawn.pontos += 1;
			Debug.Log(InimigoSpawn.pontos + "Kills");
			//InimigoSpawn.shopPoints++;
			int moneyChance = Random.Range(1, 3);

			if (moneyChance > 1)
			{
				Instantiate(money, balaponto.position, balaponto.rotation);
			}
			//Debug.Log(jogadorScript.shopPoints);
			//Debug.Log("Kills= " + InimigoSpawn.pontos);
			Destroy(this.gameObject);
		}

		if (Time.time - lastFired > 1 / rof)
		{
			CheckIfTimeToFire();
		}

		

		Vector3 direction = player.position - transform.position;
		direction.Normalize();

		movement = direction;

		animator.SetFloat("Horizontal", direction.x);
		animator.SetFloat("Vertical", direction.y);
		animator.SetFloat("Magnitude", direction.magnitude);
	}

	void FixedUpdate()
	{
		//moveChar(movement);
		projDirection = (player.transform.position - this.transform.position).normalized;

		float angulo = Mathf.Atan2(projDirection.y, projDirection.x) * Mathf.Rad2Deg - 90f;

		rb2.rotation = angulo;

	}


	void moveChar(Vector2 direction)
	{
		rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
	}


	public void Dano(int dano)
	{
		vidaAtual -= dano;

		healthBar.SetHealth(vidaAtual);
	}

    private void OnTriggerEnter2D(Collider2D other)
	{
		if (hit & other.tag == "Bala")
		{
			Dano(10);
			other.GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	void CheckIfTimeToFire()
	{
		lastFired = Time.time;
		GameObject bala = Instantiate(Bala, balaponto.position, balaponto.rotation);
		Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
		rb.AddForce(balaponto.up * 20f, ForceMode2D.Impulse);
		nextFire = Time.time + rof;
	}
	/*
    void BalaInimigo()
    {
        lastFired = Time.time;
        GameObject bala = Instantiate(Bala, balaponto.position, balaponto.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(balaponto.up * balaForce, ForceMode2D.Impulse);
    }
    */
}
