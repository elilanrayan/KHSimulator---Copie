using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{

    [SerializeField, Required] Animator _animator;

    [SerializeField, Required] PlayerMove _move;
    [SerializeField, Required] PlayerAttack _attack;
    [SerializeField, Required] EntityHealth _health;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Bool)]
    [SerializeField] string _isWalkingBoolParam;
    [SerializeField] string _isAttackingParam;
    [SerializeField] string _getHitParam;

    private void Reset()
    {
        _animator = GetComponent<Animator>();
        _move = GetComponentInParent<PlayerMove>();
        _attack= GetComponentInParent<PlayerAttack>();
        _health = GetComponent<EntityHealth>();

        _isWalkingBoolParam = "Walking";
        _isAttackingParam = "Attack";
        _getHitParam = "GetHit";

    }


    private void Start()
    {
        _move.OnStartMove += _move_OnStartMove;
        _move.OnStopMove += _move_OnStopMove;
        _attack.OnStartAttack += _attack_OnStartAttack;
        _attack.OnEndAttack += _attack_OnEndAttack;
        _health.OnHit += _hit_OnStartHeal;
        _health.OnEndHit += _hit_OnEndHeal;
    }

    private void _move_OnStartMove()
    {
        _animator.SetBool(_isWalkingBoolParam, true);
    }

    private void _move_OnStopMove()
    {
        _animator.SetBool(_isWalkingBoolParam, false);
    }

    private void _attack_OnStartAttack()
    {
        _animator.SetTrigger(_isAttackingParam);
    }

    private void _attack_OnEndAttack()
    {
        _animator.ResetTrigger(_isAttackingParam);
    }


    private void _hit_OnStartHeal()
    {
        _animator.SetTrigger(_getHitParam);
    }

    private void _hit_OnEndHeal()
    {
        _animator.ResetTrigger(_getHitParam);
    }
}
