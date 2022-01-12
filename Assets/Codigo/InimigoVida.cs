using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    [SerializeField]
    public int vida;
    public AudioClip morte;

    void Update()
    {
        if(vida < 1)
        {
            Destroy(gameObject);
            //SoundManager.instance.PlaySoundFX(morte);
        }
    }
}
