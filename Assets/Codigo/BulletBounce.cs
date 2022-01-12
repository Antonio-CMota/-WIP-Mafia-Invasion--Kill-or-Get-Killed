using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBounce : MonoBehaviour
{
	private Rigidbody2D rb;

	public TiroEliminar tiroEliminar;

	public bool top;
	public bool bottom;
	public bool mid;
	

	Vector2 ultimaVelocidade;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		ultimaVelocidade = rb.velocity;
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{

		if(tiroEliminar.isBounce == false)
		{

			rb.velocity = Vector3.zero;

		}

		foreach (ContactPoint2D hitPos in collision.contacts)
		{
			if (hitPos.normal.y < 0)
				top = true;
			else if (hitPos.normal.y > 0)
				bottom = true;
			else
				mid = true;
		}

		




		if (tiroEliminar.isBounce)
		{
			var speed = ultimaVelocidade.magnitude;
			var direction = Vector2.Reflect(ultimaVelocidade.normalized, collision.contacts[0].normal);
			rb.velocity = direction * Mathf.Max(speed, 20f);
			transform.rotation = Quaternion.Inverse(transform.rotation);

			if (top || bottom)
			{
				transform.Rotate(0, 0, 180);
			}
			
		}
	}




















}
