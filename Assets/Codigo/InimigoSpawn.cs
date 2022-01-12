using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InimigoSpawn : MonoBehaviour
{
    [SerializeField]
    private float spawnRadio = 7, time = 1.5f;
    public static int pontos;
    // public static int shopPoints;

    private TextMeshProUGUI texto;

    public bool wave = true;

    public bool[] stages;
    public GameObject[] Inimigos;

    public GameObject[] spawnLocations;

    void Start()
    {
        //shopPoints = 0;
        texto = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

        Debug.Log(wave);

        if (stages[0] == true)
        {
           // wave = true;
            Debug.Log("Wave1");
            StartCoroutine(SpawnarInimigos1());
            stages[0] = false;
        }

        if (pontos >= 10)
        {
            if (stages[1] == true)
            {
                wave = true;
                StopCoroutine(SpawnarInimigos1());
                Debug.Log("Wave2");
                StartCoroutine(SpawnarInimigos2());
                stages[1] = false;
            }
        }

        if (pontos >= 30)
        {
            if (stages[2] == true)
            {
                wave = true;
                StopCoroutine(SpawnarInimigos2());
                Debug.Log("Wave3");
                StartCoroutine(SpawnarInimigos3());
                stages[2] = false;
            }
        }

        if (pontos >= 70)
        {
            if (stages[3] == true)
            {
                StopCoroutine(SpawnarInimigos3());
                Debug.Log("Boss");
                StartCoroutine(EsperarWave());
                Vector2 spawnPos = GameObject.Find("Player").transform.position;
                spawnPos += Random.insideUnitCircle.normalized * spawnRadio;

                Instantiate(Inimigos[3], spawnPos, Quaternion.identity);
                stages[3] = false;
            }

            if (GameObject.FindGameObjectsWithTag("Inimigo").Length == 0)
            {
                SceneManager.LoadScene(4);
            }
        }
    }

    IEnumerator EsperarWave()
    {

        wave = false;
        texto.text = "A Ronda vai começar em...";

        for (int i = 10; i >= 0; i--)
        {
            yield return new WaitForSeconds(1f);
            texto.text = i.ToString();
        }

        texto.text = "";

    }




    IEnumerator SpawnarInimigos1()
    {

        if (wave == true)
        {
            StartCoroutine(EsperarWave());
            yield return new WaitForSeconds(12f);
        }

        for (int i = 1; i <= 10; i++)
        {

            Vector2 spawnPos = spawnLocations[Random.Range(0, 6)].transform.position;

            Instantiate(Inimigos[0], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(time);

            Debug.Log(i);
        }
    }


    IEnumerator SpawnarInimigos2()
    {
        if (wave == true)
        {
            StartCoroutine(EsperarWave());
            yield return new WaitForSeconds(12f);
        }

        for (int i = 1; i <= 10; i++)
        {
            Vector2 spawnPos = GameObject.Find("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadio;

            Instantiate(Inimigos[0], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(time);
            Instantiate(Inimigos[1], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(time);
            Debug.Log(i);
        }

    }
    IEnumerator SpawnarInimigos3()
    {
        if (wave == true)
        {
            StartCoroutine(EsperarWave());
            yield return new WaitForSeconds(12f);
        }


        for (int i = 1; i <= 10; i++)
        {
            Vector2 spawnPos = GameObject.Find("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadio;

            Instantiate(Inimigos[0], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(time);
            Instantiate(Inimigos[1], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(time);
            Instantiate(Inimigos[2], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(time);
            Debug.Log(i);
        }
    }
}
