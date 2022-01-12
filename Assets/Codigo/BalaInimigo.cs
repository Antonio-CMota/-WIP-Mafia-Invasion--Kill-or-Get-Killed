using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaInimigo : MonoBehaviour
{

    public float moveSpeed = 7f;
    public int dano;


    Rigidbody2D rb;

    public GameObject target;
    Vector2 moveDirection;

    bool hit = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (hit & other.tag == "Player")
        {
            Debug.Log("hit");
            other.gameObject.GetComponent<Jogador>().TakeDamage(dano);
            Destroy(gameObject);
        }
    }


}
