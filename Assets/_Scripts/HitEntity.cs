using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    [SerializeField] PlayerAttack _playerAttack;
    [SerializeField] GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        _playerAttack =player.GetComponent<PlayerAttack>();
        
    }


    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( _playerAttack.IsAttacking && other != player )
        {
            if (other.TryGetComponent<EntityHealth>(out EntityHealth entityHealth))
            {
                entityHealth.TakeDamage(10);
               
            }

        }
    }

   // bool IsAttack()
   // {
   //     return _playerAttack.IsAttacking;
   // }
}
