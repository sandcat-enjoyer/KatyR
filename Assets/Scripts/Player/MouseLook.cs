using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public static float mouseSensitivity = 0f;
    public Transform playerBody;

    float xRotation = 0f;

    public GameObject ThirdpersonCamera;
    public GameObject FirstpersonCamera;

    //Meow :3
    void Start()
    {
        if (PlayerPrefs.GetInt("ThirdpersonState") == 1)
        {
            FirstpersonCamera.SetActive(false);
            ThirdpersonCamera.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.Locked;

        if (PlayerPrefs.HasKey("StoredSensitivity"))
        {
            mouseSensitivity = PlayerPrefs.GetFloat("StoredSensitivity");
        }
        else
        {
            mouseSensitivity = 300f;
        }
    }

    void Update()
    {
        float mouseInputX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseInputY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseInputY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseInputX);
    }
}
