using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _speed = 12f;
    public float _gravity = -9.81f;
    public float _jumpHeight = 3f;
    public CharacterController _controller;
    public Transform _groundCheck;
    public float _groundDistance = 0.4f;
    public LayerMask _groundMask;

    private Vector3 _velocity;
    private bool _isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;
        else if (!_isGrounded)
        {
            _velocity.y += _gravity * Time.deltaTime; //Mathf.Pow(Time.deltaTime, 2);
        }
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
        _controller.Move((move * _speed * Time.deltaTime) + (_velocity * Time.deltaTime));
    }
}
