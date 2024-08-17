using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{private PlayerMovement3D playerMovement3D;
    public GameObject[] items;
    public Image[] images;
    public Item hasItem;
    public bool bagUsing;

    private void Awake()
    {
        playerMovement3D = GetComponent<PlayerMovement3D>();
       
    }

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        playerMovement3D.MoveTo(new Vector3(hAxis, 0, vAxis));

        if (Input.GetKeyDown(KeyCode.Space)) //점프
            playerMovement3D.JumpTo();

        //Vector3 moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        //Vector3 move = moveVec * speed * (isRun ? 2f : 1f) * Time.deltaTime;
        //rigid.MovePosition(transform.position + move);
        //transform.LookAt(transform.position + moveVec); //지정된 벡터를 향해서 회전시켜줌


        // 구현만 (추후에 줍거나 하는 수단이 생기면 다시 만들 예정)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 1; i < images.Length; i++)
            {
                images[i].color = new Color(1, 1, 1, 0.3921569f);
                items[i].SetActive(false);
            }
            images[0].color = new Color(0.1764706f, 0.1764706f, 0.1764706f, 0.5411765f);
            items[0].SetActive(true);
            hasItem = items[0].GetComponent <Item>();
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < images.Length; i++)
            {
                if(i == 1)
                    continue;
                images[i].color = new Color(1, 1, 1, 0.3921569f);
                items[i].SetActive(false);
            }
            images[1].color = new Color(0.1764706f, 0.1764706f, 0.1764706f, 0.5411765f);
            items[1].SetActive(true);
            hasItem = items[1].GetComponent<Item>();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (i == 2)
                    continue;
                images[i].color = new Color(1, 1, 1, 0.3921569f);
                items[i].SetActive(false);
            }
            images[2].color = new Color(0.1764706f, 0.1764706f, 0.1764706f, 0.5411765f);
            items[2].SetActive(true);
            hasItem = items[2].GetComponent<Item>();

        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (i == 3)
                    continue;
                images[i].color = new Color(1, 1, 1, 0.3921569f);
                items[i].SetActive(false);
            }
            images[3].color = new Color(0.1764706f, 0.1764706f, 0.1764706f, 0.5411765f);
            items[3].SetActive(true);
            hasItem = items[3].GetComponent<Item>();

        }
        else if(Input.GetKeyDown (KeyCode.Alpha5))
        {
            if (bagUsing)
            {
                for (int i = 0; i < images.Length - 1; i++)
                {
                    images[i].color = new Color(1, 1, 1, 0.3921569f);
                    items[i].SetActive(false);
                }
                images[4].color = new Color(0.1764706f, 0.1764706f, 0.1764706f, 0.5411765f);
                items[4].SetActive(true);
                hasItem = items[4].GetComponent<Item>();
            }
        }
        

        if (hasItem != null)
        {
            if(hasItem is Bag)
            {
                if (!bagUsing)
                {
                    hasItem.UseItem();
                    bagUsing = GameObject.FindObjectOfType<Bag>().bagUsing;
                }

                
            }
            else
            {
                hasItem.UseItem();
            }

        }
    }
}
