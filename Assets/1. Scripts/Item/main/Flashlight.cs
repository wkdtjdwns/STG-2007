using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Flashlight : Item
{
    public Light spotLight;
    bool isOn = false;
    public override void UseItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isOn = !isOn;
            spotLight.enabled = isOn;
        }
    }
}
