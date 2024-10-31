using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _jumpInput;
    [SerializeField] bool _isJumping = false;
    [SerializeField] Rigidbody _rb;
    [SerializeField, Range(0, 100)]
    float _speed;


    public event Action OnStartMove;
    public event Action OnStopMove;


    Coroutine MovementRoutine { get; set; }
    Coroutine _coroutineJump;

    private void Reset()
    {
        _rb = GetComponent<Rigidbody>();
        _speed = 10f;
    }

    private void OnValidate()
    {
        if(_speed <= 0)
        {
            Debug.LogWarning("Attention");
            _speed = 10;
        }
    }



    private void Start()
    {
        _move.action.started += StartMove;
        _move.action.canceled += StopMove;
        _jumpInput.action.started += StartJump;
        _jumpInput.action.canceled += StopJump;
    }
    private void OnDestroy()
    {
        _move.action.started -= StartMove;
        _move.action.canceled -= StopMove;
        _jumpInput.action.started -= StartJump;
        _jumpInput.action.canceled -= StopJump;
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        MovementRoutine = StartCoroutine(Move());
        IEnumerator Move()
        {
            OnStartMove?.Invoke();
            while (true)
            {
                var direction = obj.ReadValue<Vector2>();
                var v3 = new Vector3(direction.x, 0, direction.y);
                _rb.linearVelocity = v3 * _speed;

                yield return new WaitForFixedUpdate();
            }
        }
    }

    private void StopMove(InputAction.CallbackContext obj)
    {
        OnStopMove?.Invoke();
        _rb.linearVelocity = Vector3.zero;

        StopCoroutine(MovementRoutine);
        //MovementRoutine = null;
    }

    private void StartJump(InputAction.CallbackContext context)
    {
        _coroutineJump = StartCoroutine(Jump());
        IEnumerator Jump()
        {

            while (true)
            {
                if (!_isJumping && IsGrounded())
                {
                    _rb.AddForce(Vector3.up * 500);
                    _isJumping = true;
                }
                yield return new WaitForFixedUpdate();
            }


        }


    }

    private void StopJump(InputAction.CallbackContext context)
    {
        StopCoroutine(_coroutineJump);
        _isJumping = false;

    }

    bool IsGrounded()
    {

        return Physics.Raycast(transform.position, Vector3.down, 2f);
    }


}
