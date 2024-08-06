using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : Item
{
    Image[] images;
    public bool bagUsing;

    public void Start()
    {
        images = GameObject.FindObjectOfType<Player>().images;
        bagUsing = false;
    }


    public override void UseItem()
    {
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < images.Length - 1; i++) 
            {
                images[i].transform.Translate(-85, 0,0);
            }

            images[4].enabled = true;  
            bagUsing = true;
        }
    }
}
