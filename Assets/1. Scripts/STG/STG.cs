using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class STG : MonoBehaviour
{
    [Header("STG Info")]
    public float speed = 5f;
    public float hp = 100;
    public float detectionRange = 5.0f; // 플레이어를 따라오는 최대 거리
    public Transform target;

    [Header("Other")]
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        target = player.transform;
    }

    // STGTest 클래스에서 Overriding할 수 있도록 virtual 키워드를 통해 가상 메서드로 정의함.
    public virtual void Move()
    {
        if (target != null)
        {
            // 플레이어와의 거리 계산
            float distance = Vector3.Distance(this.transform.position, target.position);

            // 일정 거리 이상 가까워져 있을 때만 따라다님
            if (distance < detectionRange)
            {
                // Player를 향한 방향 계산 및 이동
                Vector3 direction = (target.position - transform.position).normalized;
                this.transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    public virtual void Hit(float damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            print("주금 ㅠ");
        }
    }
}
