using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageBtnCont : MonoBehaviour
{
    int levelat; 
    public GameObject stageNumObject;
    private GameObject stageData;

    void Start()
    {
        Button[] stages = stageNumObject.GetComponentsInChildren<Button>();
        stageData = GameObject.Find("StageData");
        levelat = PlayerPrefs.GetInt("levelReached");
        print(levelat);
        for (int i = levelat + 1; i < stages.Length; i++)
        {
            stages[i].interactable = false;
        }
    }

    public void Stage1_Selected()
    {
        stageData.GetComponent<StageSave>().currentStage = 1;
        DontDestroyOnLoad(stageData);
        SceneManager.LoadScene("stage1_1");
    }
    public void Stage2_Selected()
    {
        stageData.GetComponent<StageSave>().currentStage = 2;
        DontDestroyOnLoad(stageData);
        SceneManager.LoadScene("stage1_2");
    }
    public void Stage3_Selected()
    {
        stageData.GetComponent<StageSave>().currentStage = 3;
        DontDestroyOnLoad(stageData);
        SceneManager.LoadScene("stage1_3");
    }
    public void Stage4_Selected()
    {
        stageData.GetComponent<StageSave>().currentStage = 4;
        DontDestroyOnLoad(stageData);
        SceneManager.LoadScene("stage2_1");
    }
    public void Stage5_Selected()
    {
        stageData.GetComponent<StageSave>().currentStage = 5;
        DontDestroyOnLoad(stageData);
        SceneManager.LoadScene("stage2_2");
    }
    public void Stage6_Selected()
    {
        stageData.GetComponent<StageSave>().currentStage = 6;
        DontDestroyOnLoad(stageData);
        SceneManager.LoadScene("stage2_3");
    }
    public void Stage7_Selected()
    {
        stageData.GetComponent<StageSave>().currentStage = 7;
        DontDestroyOnLoad(stageData);
        SceneManager.LoadScene("stage3_1");;
    }
    public void Stage8_Selected()
    {
        stageData.GetComponent<StageSave>().currentStage = 8;
        DontDestroyOnLoad(stageData);
        SceneManager.LoadScene("stage3_2");
    }
    public void Stage9_Selected()
    {
        stageData.GetComponent<StageSave>().currentStage = 9;
        DontDestroyOnLoad(stageData);
        SceneManager.LoadScene("stage3_3");
    }

}
