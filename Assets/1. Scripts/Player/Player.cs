using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private PlayerMovement3D playerMovement3D;
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
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchItem(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchItem(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchItem(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4)) SwitchItem(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5) && bagUsing) SwitchItem(4);

        if (hasItem != null)
        {
            if (hasItem is Bag bag)
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

    void SwitchItem(int index)
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (i == index)
            {
                images[i].color = new Color(0.1764706f, 0.1764706f, 0.1764706f, 0.5411765f);
                items[i].SetActive(true);
                hasItem = items[i].GetComponent<Item>();
            }
            else
            {
                images[i].color = new Color(1, 1, 1, 0.3921569f);
                items[i].SetActive(false);
            }
        }
    }
}
