using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryManager : MonoBehaviour
{
    public int diaryIndex;
    public DiaryData[] diaryData;
    [SerializeField] private DiaryDB diaryDB;

    [SerializeField] private GameObject diaryObj;
    [SerializeField] private Text nameText;
    [SerializeField] private Text indexText;
    [SerializeField] private Text diaryText;

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

    public void ShowDiary(int index)
    {
        nameText.text = diaryData[index].name;
        indexText.text = index.ToString();
        diaryText.text = diaryData[index].diary;
    }

    public void CloseDiary()
    {
        diaryObj.SetActive(false);
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