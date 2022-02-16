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
        SceneManager.LoadScene("stage1");
    }
    public void Stage2_Selected()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Stage3_Selected()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Stage4_Selected()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Stage5_Selected()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Stage6_Selected()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Stage7_Selected()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Stage8_Selected()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Stage9_Selected()
    {
        SceneManager.LoadScene("GameScene");
    }

}
