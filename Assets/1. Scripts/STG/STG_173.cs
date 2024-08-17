using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STG_173 : STG
{
    public Light spotlight;  // 몬스터가 반응할 빛

    private bool isInLight = false;

    void Update()
    {
        CheckIfInLight();

        if (!isInLight)
        {
            Move();
        }
    }

    /// <summary>
    /// 몬스터가 빛의 범위 안에 있는지 확인하는 함수
    /// </summary>
    void CheckIfInLight()
    {
        // 몬스터와 빛 사이의 방향 벡터를 계산
        Vector3 directionToMonster = transform.position - spotlight.transform.position;

        // 빛의 정면과 몬스터 사이의 각도를 계산
        float angle = Vector3.Angle(spotlight.transform.forward, directionToMonster);

        // 빛의 각도와 범위 내에 몬스터가 있는지 확인
        // - 빛의 각도 (spotAngle)의 절반보다 작고
        // - 빛의 범위 (range) 내에 있을 경우
        if (angle < spotlight.spotAngle / 2 && directionToMonster.magnitude < spotlight.range)
        {
            // 몬스터가 빛 안에 있음
            isInLight = true;
        }
        else
        {
            // 몬스터가 빛 밖에 있음
            isInLight = false;
        }
    }
}
