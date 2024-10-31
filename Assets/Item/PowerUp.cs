using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
   

    public override void Use(PickUpItem pui)
    {
        base._health.CurrentHealth = base._health.MaxHealth;

        base.Use(pui);

    }

}
