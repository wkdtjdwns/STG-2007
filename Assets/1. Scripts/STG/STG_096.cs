using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MoveDirection
{
    Forward,
    Back,
    Left,
    Right
};

public class STG_096 : STG
{
    [SerializeField] private MoveDirection moveType;

    private Vector3 direction;
    void Start()
    {
        // 초기 이동 방향 설정
        switch (moveType)
        {
            case MoveDirection.Forward:
                direction = Vector3.forward;
                break;
            case MoveDirection.Back:
                direction = Vector3.back;
                break;
            case MoveDirection.Left:
                direction = Vector3.left;
                break;
            case MoveDirection.Right:
                direction = Vector3.right;
                break;
        }
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
    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public override void Hit(float damage)
    {
        // 피격 애니매이션 넣기
        print("아파요");
        base.Hit(damage); // STG 클래스에 있던 Hit(float damage) 메서드 불러오기
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            // 벽에 부딪히면 180도 회전
            direction = -direction;
        }
    }
}
