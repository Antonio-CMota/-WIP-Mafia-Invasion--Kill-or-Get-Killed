using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public Joystick joystick;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * speed * Time.deltaTime);
        transform.Translate(new Vector3(joystick.GetAxis("Horizontal"), 0f, joystick.GetAxis("Vertical")) * speed * Time.deltaTime);
    }
}
