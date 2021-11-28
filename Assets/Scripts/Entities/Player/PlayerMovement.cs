using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    private GameManagerSingleton _gameManagerSingleton;
    private Vector3 _velocity;
    private bool _isGrounded = false;

    private void Start()
    {
        _gameManagerSingleton = GameObject.Find("GameManager").GetComponent<GameManagerSingleton>();
        if (_gameManagerSingleton._checkPoint)
            transform.position = _gameManagerSingleton._savePosition;
        Time.timeScale = 1;
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;
        else if (!_isGrounded)
            _velocity.y += _gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && _isGrounded && Time.timeScale == 1)
            _velocity.y += Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        _controller.Move((move * _speed * Time.deltaTime) + (_velocity * Time.deltaTime));
    }
}
