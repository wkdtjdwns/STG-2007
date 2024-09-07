using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STG_469 : STG
{
     public float threshold = -20f; // dB 임계값 설정
    
    private AudioClip micClip;
    private bool isOverThreshold;

    void Start()
    {
        // 마이크에서 오디오 입력 시작
        micClip = Microphone.Start(null, true, 1, 44100);
    }

    void Update()
    {
        // 마이크 음량 감지
        float volume = GetMicVolume();
        //디폴트 : -90
        //마이크 크면 : -50 ~ -5
        print("volume : " + volume);
        // 음량이 임계값을 넘으면 이벤트 실행  
        if(volume > threshold && !isOverThreshold)
        {
            isOverThreshold = true;
            print("over");
        }
        else if(volume <= threshold)
        {
            isOverThreshold = false;  
        }
    }

    float GetMicVolume()
    {
        float levelMax = 0;
        float[] waveData = new float[128];
        int micPosition = Microphone.GetPosition(null) - 128 + 1;
        if (micPosition < 0) return 0;
        micClip.GetData(waveData, micPosition);

        // 오디오 데이터에서 최대 음량 레벨 계산
        for (int i = 0; i < 128; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return 20 * Mathf.Log10(Mathf.Sqrt(levelMax));
    }
}
