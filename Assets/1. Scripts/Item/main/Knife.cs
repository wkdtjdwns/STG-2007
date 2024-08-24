using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Item
{
    public override void UseItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("½´½µ");
        }
    }

}
