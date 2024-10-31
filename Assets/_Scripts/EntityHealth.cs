using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{

    [SerializeField] int _maxHealth;
    public event Action OnHit;
    public event Action OnEndHit;
    public int CurrentHealth { get;set; }
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    private void Start()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    private void Update()
    {
        if(CurrentHealth < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
