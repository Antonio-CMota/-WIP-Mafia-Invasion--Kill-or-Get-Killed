using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    float moveSpeed1;
    float parar = 0;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 movimento;
    public Vector2 projDirection;
    public Transform balaponto;

    public Rigidbody2D rb2;

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

    public bool[] stages;

    bool isshooting = true;
    bool esperar;
    bool isatacar;
    bool isagarrar;
    public bool agarrou;
    public GameObject cameraa;
    public GameObject playeranim;
    public float range;


    int totaltouch;
    int contar;
    int contarbala;
    public GameObject Canvas;
    public GameObject BotaoLargar;



    void Start()
    {
        agent.speed = 1.3f;
        agent.acceleration = 8f;
        moveSpeed1 = agent.speed;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = this.GetComponent<Rigidbody2D>();

        cameraa = GameObject.Find("/Player/Main Camera");
        playeranim = GameObject.Find("/Player/Player");
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        BotaoLargar = GameObject.FindGameObjectWithTag("BotaoLargar");

        vidaAtual = MaxVida;
        healthBar.SetMaxHealth(MaxVida);

        stages[0] = true;
        isatacar = true;

        BotaoLargar.SetActive(false);

    }

    void Update()
    {

        if (stages[0] == true)
        {
            if (isatacar == true)
            {
                StartCoroutine(Ataque());
            }

            if (agarrou == true)
            {
                if (isagarrar == false)
                {
                    Invoke("agarrar", 0f);
                }

            }

        }



        if (stages[1] == true)
        {
            if (contarbala < 500)
            {
                if (isshooting == true)
                {
                    balaponto.transform.position = gameObject.transform.position;
                    CheckIfTimeToFire();
                }
            }

            if (contarbala == 499)
            {
                StartCoroutine(Carregararma());
                StartCoroutine(Esperar());
            }

        }

    }

    void FixedUpdate()
    {
        projDirection = (player.transform.position - this.transform.position).normalized;

        float angulo = Mathf.Atan2(projDirection.y, projDirection.x) * Mathf.Rad2Deg - 90f;

        rb2.rotation = angulo;
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
        }

        if (vidaAtual <= 2500)
        {
            stages[0] = false;
            stages[1] = true;
        }

        if (vidaAtual <= 0)
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.name == "Player")
        {
            agarrou = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            agarrou = false;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            agarrou = false;
        }
    }

    void CheckIfTimeToFire()
    {
        lastFired = Time.time;
        GameObject bala = Instantiate(Bala, balaponto.position, balaponto.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(balaponto.up * 600f, ForceMode2D.Impulse);
        nextFire = Time.time + rof;
        contarbala++;
        Debug.Log(contarbala);
    }

    IEnumerator Carregararma()
    {
        isshooting = false;
        yield return new WaitForSeconds(5);
        contarbala = 0;
        isshooting = true;
    }




    IEnumerator Esperar()
    {
        esperar = true;
        agent.enabled = false;

        animator.SetBool("isEsperar", true);

        for (int i = 5; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
        }

        esperar = false;
        agent.enabled = true;
        animator.SetBool("isEsperar", false);
    }


    void SeguirPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        movement = direction;

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Magnitude", direction.magnitude);
    }


    IEnumerator Ataque()
    {
        isatacar = false;
        StartCoroutine(AtaqueRapido());
        yield return new WaitForSeconds(5);
        animator.SetBool("isEsperar", false);
        agent.isStopped = false;

        agent.speed = 10f;
        agent.acceleration = 20f;

        yield return new WaitForSeconds(1);

        agent.speed = 1.3f;
        agent.acceleration = 8;

        yield return new WaitForSeconds(30);

        isatacar = true;
    }


    void agarrar()
    {
        isagarrar = true;

        playeranim.GetComponent<SpriteRenderer>().enabled = true;
        player.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        cameraa.GetComponent<Animator>().SetBool("garramos", true);
        playeranim.GetComponent<Animator>().SetBool("garramos", true);

        agent.enabled = false;

        Canvas.SetActive(false);
        BotaoLargar.SetActive(true);

        totaltouch = Random.Range(10, 20);
    }

    void largar()
    {
        playeranim.GetComponent<SpriteRenderer>().enabled = false;
        player.gameObject.GetComponent<SpriteRenderer>().enabled = true;

        cameraa.GetComponent<Animator>().SetBool("garramos", false);
        playeranim.GetComponent<Animator>().SetBool("garramos", false);

        agent.enabled = true;

        Canvas.SetActive(true);
        BotaoLargar.SetActive(false);

        agent.isStopped = true;

        agent.isStopped = false;

        StartCoroutine(doissegundos());

    }

    IEnumerator AtaqueRapido()
    {
        agent.isStopped = true;
        animator.SetBool("isEsperar", true);
        yield return new WaitForSeconds(0);
    }

    public void onButtonPress()
    {
        contar++;

        if (contar >= totaltouch)
        {
            contar = 0;
            largar();
        }
    }

    IEnumerator doissegundos()
    {
        for (int i = 0; i <= 2; i++)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }
        isagarrar = false;
        Debug.Log("isagarrar = " + isagarrar);
    }


}
