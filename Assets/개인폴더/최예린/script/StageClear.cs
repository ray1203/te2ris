using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    public int stage_data;

    private void Awake() {
        stage_data = GameObject.FindObjectOfType<StageSave>().currentStage;
        //Debug.Log(stage_data);
    }
    public void gotoStageList()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void gotoNextStage()
    {  
        if (stage_data == 9)
            SceneManager.LoadScene("Start");
        SceneManager.LoadScene("stage" + (stage_data / 3 + 1).ToString() + "_" + (stage_data % 3 + 1).ToString());
        GameObject.FindObjectOfType<StageSave>().currentStage++;
    }
}
