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
    {   // scene ������ ����� �����ʿ�
        SceneManager.LoadScene("StageSelect");
    }
}
