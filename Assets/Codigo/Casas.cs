using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casas : MonoBehaviour
{
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sprite.color = new Color(1, 1, 1, 0.25f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var sprite = GetComponent<SpriteRenderer>();

            sprite.color = new Color(1, 1, 1, 1);
        }
    }
}
