using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{
    public int diaryIndex;
    public DiaryData[] diaryData;
    [SerializeField] private DiaryDB diaryDB;

    private void Awake()
    {
        diaryData = new DiaryData[diaryDB.Diary.Count];
        SetUp();
    }

    private void SetUp()
    {
        for (int i = 0; i < diaryDB.Diary.Count; ++i)
        {
            diaryData[i].diaryIndex = diaryDB.Diary[i].diaryIndex;
            diaryData[i].name = diaryDB.Diary[i].name;
            diaryData[i].diary = diaryDB.Diary[i].diary;
        }
    }
}

[System.Serializable]
public struct DiaryData
{
    public int diaryIndex;
    public string name;

    [TextArea(3, 5)]
    public string diary;
}