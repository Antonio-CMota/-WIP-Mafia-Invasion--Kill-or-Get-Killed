using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    public Image InnerStick;
    public float maximumDisplacement;

    private Vector2 deadZone;

    private Vector2 initialDisplacement;
    private Vector2 displacement;

    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        initialDisplacement = InnerStick.rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        // Debug.Log(displacement);
    }

    private void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0))
            isMoving = true;

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
            InnerStick.rectTransform.position = initialDisplacement;
            displacement = Vector2.zero;
        }

        if (isMoving)
            UpdateDisplacement();
    }

    private void UpdateDisplacement()
    {
        displacement = new Vector2(Input.mousePosition.x - initialDisplacement.x, Input.mousePosition.y - initialDisplacement.y);
        float distance = displacement.magnitude;

        if (distance > maximumDisplacement)
            displacement = displacement.normalized * maximumDisplacement;

        InnerStick.rectTransform.position = initialDisplacement + displacement;
    }

    public float GetAxis(string axis)
    {
        if (axis == "Horizontal")
            return displacement.x / maximumDisplacement;
        else
            if (axis == "Vertical")
                return displacement.y / maximumDisplacement;
            else
                return 0;
    }
}
