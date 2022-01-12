using UnityEngine.SceneManagement;
using UnityEngine;

public class Botoes : MonoBehaviour
{

    public Animator menu;
    public Animator jogar;
    public Animator creditos;
    public Animator opcoes;

    bool ismenu = false;
    bool isjogar = false;
    bool iscreditos = false;
    bool isopcoes = false;

    bool isanimacao = false;

    public GameObject Audio;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Morte");
        FindObjectOfType<AudioManager>().Play("Menu");
        FindObjectOfType<AudioManager>().Play("musicamenu");
    }

    public void Sair()
    {
        SceneManager.LoadScene(0);
    }

    public void Jogar()
    {
        jogar.SetBool("isjogar", true);
        menu.SetBool("isSair", true);
        isjogar = true;
    }

    public void irJogar()
    {
        SceneManager.LoadScene(1);
    }

    public void Opcoes()
    {
        opcoes.SetBool("isopcoes", true);
        menu.SetBool("isSair", true);
        isopcoes = true;
    }

    public void Creditos()
    {
        creditos.SetBool("iscreditos", true);
        menu.SetBool("isSair", true);
        iscreditos = true;
    }


    public void Voltar()
    {
        if(isjogar == true)
        {
            jogar.SetBool("isjogar", false);
            menu.SetBool("isSair", false);
            isjogar = false;
        }
        if (isopcoes == true)
        {
            opcoes.SetBool("isopcoes", false);
            menu.SetBool("isSair", false);
            isopcoes = false;
        }
        if (iscreditos == true)
        {
            creditos.SetBool("iscreditos", false);
            menu.SetBool("isSair", false);
            iscreditos = false;
        }
    }

    public void ligardesligar(bool issom)
    {
        if(issom == true)
        {
            Audio.gameObject.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            Audio.gameObject.GetComponent<AudioListener>().enabled = false;
        }
    }

}
