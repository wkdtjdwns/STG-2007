using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : Item
{
    public override void UseItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print(new System.Random().Next(1, 13));
        }
    }
}
