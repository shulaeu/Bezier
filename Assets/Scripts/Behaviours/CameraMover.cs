using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private Joystick rotateJoystick;

    private Vector3 inputVector;
    private bool joystickIsActive = false;

    private void Start()
    {
        UIEventHelper.SubscribeOnToggleJoystick(b =>
        {
            moveJoystick.gameObject.SetActive(b);
            rotateJoystick.gameObject.SetActive(b);
        });
    }

    private void Update()
    {
        //Debug.Log(1);
        Vector2 moveDirection = moveJoystick.Direction * moveSpeed * Time.deltaTime;
        Vector2 rotateDirection = rotateJoystick.Direction * rotateSpeed * Time.deltaTime;

        camera.transform.position += new Vector3(moveDirection.x, 0, moveDirection.y);
        camera.transform.Rotate(new Vector3(rotateDirection.y, rotateDirection.x, 0));
    }
}
