using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Joystick joystick;
    
    private Vector3 inputVector;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    private bool joystickIsActive = false;

    //private void Start()
    //{
    //    ClickEffect();
    //}

    private void Update()
    {
        //Debug.Log(1);
        //Vector2 Direction = Vector2.left * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //rb.AddForce(Direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        //public void OnDrag(PointerEventData eventData)
        //{
        //    Vector2 joystickPosition;

        //    //if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, eventData.position, null, out joystickPosition))
        //    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(eventData.position, null, out joystickPosition))
        //    {
        //        joystickPosition.x = (joystickPosition.x * 2);
        //        joystickPosition.y = (joystickPosition.y * 2);


        //        //transform.position += new Vector3(0,0,speed * Time.deltaTime);
        //    }
        //}

       // Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);


        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0,0,speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
    }
}
