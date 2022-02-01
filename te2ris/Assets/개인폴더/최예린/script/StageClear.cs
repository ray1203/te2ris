using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    public void gotoStageList()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void gotoNextStage()
    {   // scene 여러개 생기면 수정필요
        SceneManager.LoadScene("StageSelect");
    }
}
