using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STG_3284 : STG
{
    private float attackTime;
    private bool isHit;

    private void Awake()
    {
        isHit = false;
        attackTime = 2.5f;

        detectionRange = 2.5f;
        target = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (target != null)
        {
            // 플레이어와의 거리 계산
            float distance = Vector3.Distance(this.transform.position, target.position);

            // 일정 거리 이상 가까워져 있을 때만 공격함
            if (distance < detectionRange && !isHit)
            {
                StartCoroutine(Attack());
            }
        }
    }

    private IEnumerator Attack()
    {
        isHit = true;

        this.transform.position = target.position;
        print("플레이어 때찌");
        //target.GetComponent<Player>().데미지 입는 함수() (아무튼 플레이어에게 데미지를 입히는 함수면 됨);

        yield return new WaitForSeconds(attackTime);

        isHit = false;
    }

    public override void Hit(float damage)
    {
        // 피격 애니매이션 넣기
        print("아야");
        base.Hit(damage); // STG 클래스에 있던 Hit(float damage) 메서드 불러오기
    }
}
