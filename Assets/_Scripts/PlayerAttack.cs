using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public event Action OnStartAttack;
    public event Action OnEndAttack;
    [SerializeField] InputActionReference _attack;

    private Coroutine _attackCoroutine;
   [SerializeField] bool _isAttacking;
    public bool IsAttacking => _isAttacking;


    void Start()
    {
        _attack.action.started += StartAttack ;
        _attack.action.canceled += StopAttack ;
    }

  

    private void OnDestroy()
    {
      _attack.action.started -= StartAttack;
      _attack.action.canceled -= StopAttack;
    }
    

    private void StartAttack(InputAction.CallbackContext obj)
    {
        _attackCoroutine = StartCoroutine(Attack());
        IEnumerator Attack()
        {
            OnStartAttack?.Invoke();
            while (true)
            {
                //attack
                _isAttacking = true;
                yield return new WaitForFixedUpdate();
            }
        }
    }

    private void StopAttack(InputAction.CallbackContext context)
    {
        OnEndAttack?.Invoke();
        _isAttacking = false;
        StopCoroutine(_attackCoroutine);
        
    }
}
