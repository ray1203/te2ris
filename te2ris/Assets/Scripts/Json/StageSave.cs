using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class StageSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        StageData stageData = new StageData(1, 3);
        string str = ObjectToJson(stageData);
        Debug.Log(str);
        var obj = JsonToOject<StageData>(str);
        Debug.Log(obj.clearAmount);
        CreateJsonFile(Application.dataPath, "StageData", str);*/
        //var stageData = LoadJsonFile<StageData>(Application.dataPath, "StageData");
        //stageData.print();
        FileInfo file = new FileInfo(Application.dataPath+"/StageData.json");
        if(!file.Exists)
            FirstSetting();
        SaveData(0, 3);
        //Debug.Log(GetStar(0));
        //int[] arr = GetAllStars();
        //for (int i = 0; i < 10; i++) Debug.Log(arr[i]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    string ObjectToJson(object obj)
    {
        return JsonUtility.ToJson(obj);
    }

    T JsonToOject<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData);
        
    }
    void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    T LoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }
    public void FirstSetting()
    {
        TimeLimit[] timeLimits = new TimeLimit[10] {//각 스테이지 제한시간 저장
            new TimeLimit(0, 0, 0),
            new TimeLimit(180, 120, 60),
            new TimeLimit(180, 120, 60),
            new TimeLimit(180, 120, 60),
            new TimeLimit(120, 90, 60),
            new TimeLimit(120, 90, 60),
            new TimeLimit(120, 90, 60),
            new TimeLimit(90, 70, 50),
            new TimeLimit(90, 70, 50),
            new TimeLimit(90, 70, 50),
        };
        int[] clearAmount = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        StageData stageData = new StageData(clearAmount, timeLimits);
        string str = ObjectToJson(stageData);
        CreateJsonFile(Application.dataPath, "StageData", str);

    }
    public void SaveData(int stage,int star)//현 스테이지, 별 갯수
    {
        StageData stageData = LoadJsonFile<StageData>(Application.dataPath, "StageData");
        stageData.clearAmount[stage] = stageData.clearAmount[stage] < star ? star : stageData.clearAmount[stage];
        string str = ObjectToJson(stageData);
        CreateJsonFile(Application.dataPath, "StageData", str);
    }
    public int GetStar(int stage)
    {
        StageData stageData = LoadJsonFile<StageData>(Application.dataPath, "StageData");
        return stageData.clearAmount[stage];
    }
    public TimeLimit GetTimeLimit(int stage)
    {
        StageData stageData = LoadJsonFile<StageData>(Application.dataPath, "StageData");
        return stageData.timeLimits[stage];
    }
    public int[] GetAllStars()
    {
        StageData stageData = LoadJsonFile<StageData>(Application.dataPath, "StageData");
        return stageData.clearAmount;
    }
    public TimeLimit[] GetAllTimeLimits()
    {
        StageData stageData = LoadJsonFile<StageData>(Application.dataPath, "StageData");
        return stageData.timeLimits;
    }
}
