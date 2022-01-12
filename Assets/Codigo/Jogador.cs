using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{

    public MovementJoystick movementJoystick;

    public ShootingJoystick shootingJoystick;

    public float velocidade;

    public Rigidbody2D rb;

    public Rigidbody2D rb2;

    public static int shopPoints = 0;

    public static int MaxVida = 100;
    public static int vidaAtual;
    public HealthBar healthBar;

    public GameObject armaponto;
    public GameObject player;
    public Animator animator;

    public Camera cam;

    //Variaveis para Botao MoveSpeed
    public GameObject botas;
    public GameObject scriptHolderSpeed;
    public bool isCoroutineExecuting;
    public static int moveSpeedCounter;
    public GameObject moveSpeedButton;

    //Variaveis para Botao Bounce
    public TiroEliminar tiroEliminar;
    public GameObject bounce;
    public GameObject scriptHolder;
    public GameObject raio;
    public bool isBounce;
    public GameObject bounceButton;

    public static int bounceCounter = 0;
    public Collider2D colliderCirculo;

    public static int powerCounter = 0;

    public bool isMoveSpeed;

    public float baseMoveSpeed = 6f;
    public float activeSpeed = 6f;

    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    public static int moveSpeedLvl = 1;
    public static int healthLvl = 1;

    //private bool hit = true;

    Vector2 movement;
    Vector2 ratoPosicao;

    public GameObject BotaoLargar;

    private void Start()
    {
        vidaAtual = MaxVida;

        healthBar.SetMaxHealth(MaxVida);

        activeSpeed = baseMoveSpeed;

        BotaoLargar = GameObject.FindGameObjectWithTag("BotaoLargar");

        BotaoLargar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //armaponto.transform.position = player.transform.position;

        /* movement.x = Input.GetAxisRaw("Horizontal");
         movement.y = Input.GetAxisRaw("Vertical");

         movement = Vector2.ClampMagnitude(movement, 1);

         Vector3 movimento = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);

        */

        if (MoveSpeedPowerUp.moveSpeedCounter > 0)
        {
            moveSpeedButton.SetActive(true);
        }
        else
        {
            moveSpeedButton.SetActive(false);
        }

        if (BouncePowerUp.bounceCounter > 0)
        {
            bounceButton.SetActive(true);
        }
        else
        {
            bounceButton.SetActive(false);
        }

        if (healthLvl == 1)
            MaxVida = 80;
        if (healthLvl == 2)
            MaxVida = 85;
        if (healthLvl == 3)
            MaxVida = 90;
        if (healthLvl == 4)
            MaxVida = 95;
        if (healthLvl == 5)
            MaxVida = 100;

        if (moveSpeedLvl == 1)
            baseMoveSpeed = 6f;
        if (moveSpeedLvl == 2)
            baseMoveSpeed = 6.6f;
        if (moveSpeedLvl == 3)
            baseMoveSpeed = 8.085f;
        if (moveSpeedLvl == 4)
            baseMoveSpeed = 8.1f;
        if (moveSpeedLvl == 5)
            baseMoveSpeed = 9f;

        if (!isMoveSpeed)
        {
            activeSpeed = baseMoveSpeed;
        }

        if(vidaAtual <= 0)
        {
            SceneManager.LoadScene(3);

            FindObjectOfType<AudioManager>().Play("Morte");
        }


        animator.SetFloat("Horizontal", movementJoystick.joystickVec.x);
        animator.SetFloat("Vertical", movementJoystick.joystickVec.y);
        animator.SetFloat("Magnitude", movementJoystick.joystickVec.magnitude);

        ratoPosicao = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        if (movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * activeSpeed, movementJoystick.joystickVec.y * activeSpeed);
        }

        else
        {
            rb.velocity = Vector2.zero;
        }

        //rb.MovePosition(rb.position + movement * velocidade * Time.fixedDeltaTime);

        float angulo = Mathf.Atan2(shootingJoystick.joystickVec.y, shootingJoystick.joystickVec.x) * Mathf.Rad2Deg - 90f;

        rb2.rotation = angulo;

    }

    public void TakeDamage(int damageAmount)
    {
        vidaAtual -= damageAmount;
        // other stuff you want to happen when enemy takes damage
        healthBar.SetHealth(vidaAtual);
        FindObjectOfType<AudioManager>().Play("Hit");
    }

    public void MoveSpeed()
    {
        if (MoveSpeedPowerUp.moveSpeedCounter >= 1)
        {
            isMoveSpeed = true;
            if (isMoveSpeed)
            {
                activeSpeed = baseMoveSpeed + Random.Range(1, 5);
            }
            MoveSpeedPowerUp.moveSpeedCounter--;

            StartCoroutine(EndMoveSpeed());
        }
    }

    IEnumerator EndMoveSpeed()
    {

        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(5);

        isMoveSpeed = false;

        isCoroutineExecuting = false;

        Destroy(scriptHolderSpeed);

    }

    public void Bounce()
    {
        if (BouncePowerUp.bounceCounter >= 1)
        {

            isBounce = true;
            if (isBounce)
            {
                raio.GetComponent<BulletBounce>().enabled = true;
                tiroEliminar.isBounce = true;
            }

            BouncePowerUp.bounceCounter--;

            StartCoroutine(EndBounce());

        }
    }

    IEnumerator EndBounce()
    {

        Debug.Log("Start");

        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(5);

        tiroEliminar.isBounce = false;
        tiroEliminar.waitTime = 0.25f;
        raio.GetComponent<BulletBounce>().enabled = false;

        isCoroutineExecuting = false;

        Destroy(scriptHolder);

    }
    /*

     private void OnTriggerEnter2D(Collider2D other)
     {
         if (hit & other.tag == "BalaInimigo")
         {
             Dano(10);
         }

         if (vidaAtual <= 0)
         {
             Destroy(this.gameObject);
             SceneManager.LoadScene(1);
         }
     }

     void Dano(int dano)
     {
         vidaAtual -= dano;

         healthBar.SetHealth(vidaAtual);
     }



     */
}
