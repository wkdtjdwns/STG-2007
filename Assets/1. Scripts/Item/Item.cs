using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{

    public virtual void UseItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("아이템 사용");
        }
    }

}
