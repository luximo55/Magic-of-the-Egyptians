using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private float speed = 10.0f;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movedirection;
    public float CameraSensitivity = 2.0f;
    private float yaw = 0.0f;
    public int lives = 5;
    

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Ovaj dio koda brine za kretanje lika
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movedirection = new Vector3(horizontalInput , 0 ,verticalInput);
        transform.Translate(movedirection * speed * Time.deltaTime);
        
        //Ovaj dio kod brine od micanju kamere
        yaw += CameraSensitivity * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}
