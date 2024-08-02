using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGTest : STG
{
    private void Awake()
    {
        
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hit(10);
        }
    }

    // STG 클래스의 Move() 메서드 오버라이딩
    public override void Move()
    {
        print("Move() 오버라이딩");
        base.Move(); // STG 클래스에 있던 Move() 메서드 불러오기
    }

    public override void Hit(float damage)
    {
        // 피격 애니매이션 넣기
        print("아파요");
        base.Hit(damage); // STG 클래스에 있던 Hit(float damage) 메서드 불러오기
    }
}
