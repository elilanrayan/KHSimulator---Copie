using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] UnityEvent _destroyFeedback;
    public EntityHealth _health;
    public EntityGold _gold;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        _health = player.GetComponent<EntityHealth>();
        _gold = player.GetComponent<EntityGold>();
    }

    

    public virtual void Use(PickUpItem pui)
    {

        // consume bag

        _destroyFeedback?.Invoke();
        Destroy(gameObject, 3f);
    }

}
