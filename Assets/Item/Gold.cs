using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{

    public override void Use(PickUpItem pui)
    {
        base._gold.Gold +=1;

        base.Use(pui);

    }
}
