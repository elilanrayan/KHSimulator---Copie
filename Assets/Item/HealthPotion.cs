using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    

    
    public override void Use(PickUpItem pui)
    {
        base._health.CurrentHealth += base._health.CurrentHealth;
        
        base.Use(pui);

    }

}
