using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodirC4 : MonoBehaviour
{

    public float ExplosionRange;
    public float TimeToDetonate;
    public float TimeToDestroy;

    public LayerMask WhatToDestroy;

    float ActualTimeToDestroy;

    public Animator anim;

    void Start()
    {
        ActualTimeToDestroy = TimeToDetonate + TimeToDestroy;
    }

    void Update()
    {
        if (TimeToDetonate <= 0)
        {
            anim.SetBool("explosao", true);
            Detonar();
        }

        if (TimeToDetonate > 0)
        {
            TimeToDetonate -= Time.deltaTime;
        }

        if (ActualTimeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
        if (ActualTimeToDestroy > 0)
        {
            ActualTimeToDestroy -= Time.deltaTime;
        }

    }


    void Detonar()
    {
        Collider2D[] ObjetoparaDestroir = Physics2D.OverlapCircleAll(transform.position, ExplosionRange, WhatToDestroy);
        for (int i = 0; i < ObjetoparaDestroir.Length; i++)
        {
            if (ObjetoparaDestroir[i].name == "Boss")
            {
                ObjetoparaDestroir[i].GetComponent<Boss>().Dano(1);
            }
            else 
            { 
                ObjetoparaDestroir[i].GetComponent<Enemy>().Dano(20);
            }
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRange);
    }




}
