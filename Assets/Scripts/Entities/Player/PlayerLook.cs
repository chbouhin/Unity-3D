using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float _mouseSensitivity = 200f;
    public Transform _playerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation - mouse_y, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouse_x);
    }
}
