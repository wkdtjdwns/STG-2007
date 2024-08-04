using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{private PlayerMovement3D playerMovement3D;

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

        if (Input.GetKeyDown(KeyCode.Alpha1))
            print(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            print(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) 
            print(3);
        else if(Input.GetKeyDown(KeyCode.Alpha4))
            print(4);
    }
}
