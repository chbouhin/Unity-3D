using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 200f;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Camera _playerCam;
    [SerializeField] private LayerMask _layerToIgnore;
    [SerializeField] private float _interactRange = 4f;

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
        if (Input.GetKeyDown("e")) {
            TryInteractWithDoor();
        }
    }

    private void TryInteractWithDoor()
    {
        RaycastHit hit;
        if (Physics.Raycast(_playerCam.transform.position, _playerCam.transform.forward, out hit, _interactRange, ~((int)_layerToIgnore))) {
            InteractWithDoor doorOpener = hit.transform.GetComponentInParent<InteractWithDoor>();
            if (doorOpener != null)
                if (!doorOpener.open) {
                    doorOpener.OpenDoor();
                } else {
                    doorOpener.CloseDoor();
                }
        }
    }
}
