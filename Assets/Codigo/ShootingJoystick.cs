using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootingJoystick : MonoBehaviour
{

	public Vector2 crosshairOriginalPos;
	public GameObject crosshair;
	public GameObject crosshairEmpty;
	//public GameObject muzzle;

	public GameObject armaponto;
	public int raio;

	public GameObject joystick;
	public GameObject joystickBG;
	public Vector2 joystickVec;
	private Vector2 joystickTouchPos;
	private Vector2 joystickOriginalPos;
	private float joystickRadius;
	
	Rect right;
	

	// Start is called before the first frame update
	void Start()
	{
		joystickOriginalPos = joystickBG.transform.position;

		joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
		
		
		right = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2);

	}

	private void Update()
	{
		crosshairOriginalPos = crosshairEmpty.transform.position;
	}

	// Update is called once per frame
	public void PointerDown()
	{
		if (right.Contains(Input.mousePosition))
		{
			joystick.transform.position = Input.mousePosition;
			joystickBG.transform.position = Input.mousePosition;
			joystickTouchPos = Input.mousePosition;
		}
	}

	public void Drag(BaseEventData baseEventData)
	{

		PointerEventData pointerEventData = baseEventData as PointerEventData;
		Vector2 dragPos = pointerEventData.position;
		joystickVec = (dragPos - joystickTouchPos).normalized;

		float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

		if (joystickDist < joystickRadius)
		{
			joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
			crosshair.transform.position = crosshairOriginalPos + joystickVec * joystickDist;
			armaponto.transform.position = crosshairOriginalPos + joystickVec * joystickDist;
			//muzzle.transform.position = crosshairOriginalPos + joystickVec * joystickDist;

		}

		else
		{
			joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
			crosshair.transform.position = crosshairOriginalPos + joystickVec * joystickRadius / 8;
			armaponto.transform.position = crosshairOriginalPos + joystickVec * joystickRadius / raio;
			//muzzle.transform.position = crosshairOriginalPos + joystickVec * joystickRadius / (raio * 2);
		}


	}

	public void PointerUp()
	{
		joystickVec = Vector2.zero;
		joystick.transform.position = joystickOriginalPos;
		joystickBG.transform.position = joystickOriginalPos;
		crosshair.transform.position = crosshairOriginalPos;
		armaponto.transform.position = crosshairOriginalPos;
		//muzzle.transform.position = crosshairOriginalPos;
	}

}

